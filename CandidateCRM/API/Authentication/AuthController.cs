using AutoMapper;
using ERP.Common.Services;
using Microsoft.AspNetCore.Mvc;
using CRM.Authentication.Model;
using ERP.Authentication.Domain;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace CandidateCRM.API.Authentication
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly ILogger<AuthController> logger;
        private readonly IAuthManager authManager;
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IPasswordReset_Service _passwordService;
        private readonly IEmail_Service _emailService;
        public AuthController
        (
          IHttpClientFactory httpClientFactory,
          IMapper mapper, ILogger<AuthController> logger,
          IAuthManager authManager,
          IPasswordReset_Service passwordReset_Service,
          IEmail_Service emailService
        )
        {

            this.mapper = mapper;
            this.logger = logger;
            this.authManager = authManager;
            _httpClientFactory = httpClientFactory;
            _passwordService = passwordReset_Service;
            _emailService = emailService;

        }


        [HttpPut]
        [Route("UpdateProfile")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Administrator,Candidate,HR")]
        public async Task<ActionResult> UpdateProfile([FromBody] UpdateUserModel loginDto)
        {
            var authResponse = await authManager.UpdateUser(loginDto);

            return Ok(authResponse);
        }

        [HttpPost]
        [Route("register")]
        public async Task<ActionResult> Register([FromBody] RegisterUserModel apiUserDto)
        {
            IList<IdentityError> errors = (IList<IdentityError>)await authManager.RegisterCandidates(apiUserDto);
            if (errors.Any())
            {
                foreach (var error in errors)
                {
                    ModelState.AddModelError(error.Code, error.Description);
                }
                return BadRequest(errors.Select(x => x.Description).FirstOrDefault());
            }
            var successResponse = new SuccessResponse
            {
                Message = "User Registered Successfully"
            };
            return Ok(successResponse);
        }

        [HttpPost]
        [Route("login")]
        public async Task<ActionResult> Login([FromBody] UserLoginModel loginDto)
        {

            try
            {
                return Ok(await authManager.Login(loginDto));
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }
        }        

        [HttpGet]
        [Route("getById")]

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Administrator,Candidate,HR,HRStaff")]
        public async Task<ActionResult> getById(string uid)
        {
            try
            {
                var authResponse = await authManager.FindById(uid);
                return Ok(authResponse);
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }
        }
        [HttpPost]
        [Route("SendComfirmEmail")]
        //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Administrator,Student,Teacher")]
        public async Task<ActionResult> SendComfirmEmail(ForgotPasswordModel model)
        {
            try
            {
                string message = await authManager.SendComfirmEmail(model.Email);
                return Content($"{{ \"message\": \"{message}\" }}", "application/json");
            }
            catch (Exception ex)
            {

                return StatusCode(500, "An error occurred while sending the confirmation email." + ex.Message);
            }
        }
        [HttpPost]
        [Route("ComfirmEmail")]
        //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Administrator,Student,Teacher")]
        public async Task<ActionResult> ComfirmEmail(ConfirmEmail model)
        {
            try
            {
                string message = await authManager.ComfirmEmail(model.Email, model.OTP);
                return Content($"{{ \"message\": \"{message}\" }}", "application/json");
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred while sending the confirmation email." + ex.Message);
            }
        }


        [HttpPost("ForgotPassword")]
        public async Task<IActionResult> ForgotPassword(ForgotPasswordModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await authManager.FindbyEmail(model.Email);
                if (user == null)
                {
                    ModelState.AddModelError(string.Empty, "User not found");
                    return BadRequest(ModelState);
                }
                var otp = GenerateRandomOTP(8);
                var expirationTime = DateTime.Now.AddMinutes(15);

                // Create a PasswordResetRequest and store it
                var resetRequest = new PasswordResetDomain
                {
                    Email = model.Email,
                    ExpireTime = expirationTime,
                    OTP = otp
                };

                string retValue = await StorePasswordResetRequest(resetRequest);
                if (!retValue.StartsWith("OK"))
                {
                    return BadRequest(retValue);
                }
                string subject = "Password Reset OTP";
                string body = "<h3> This is your Password reset OTP Please don't share with anyone.</h3> \r\n\n\n  <h1>" + otp + "</h1> \r\n\n";
                retValue = await SendPasswordResetOTPEmailAsync(model.Email, subject, body);
                if (!retValue.StartsWith("OK"))
                {
                    return BadRequest(retValue);
                }
                var message = "Password reset instructions sent to your email.";
                return Content($"{{ \"message\": \"{message}\" }}", "application/json");
            }

            return BadRequest(ModelState);
        }

        [HttpPost("RestPassword")]
        public async Task<IActionResult> RestPassword(ResetModel model)
        {
            string message;
            if (ModelState.IsValid)
            {
                ApplicationUser user = await authManager.FindbyEmail(model.Email);
                if (user == null)
                {

                    return BadRequest("User not found");
                }
                IList<PasswordResetDomain> otplist = (IList<PasswordResetDomain>)await _passwordService.GetAll();
                if (otplist.Count == 0)
                {
                    return BadRequest("No OTP Found");
                }
                PasswordResetDomain otp = otplist.Where(x => x.Email == model.Email).OrderBy(x => x.ExpireTime).LastOrDefault();
                if (otp == null)
                {
                    message = "No OTP against your email found";
                    return Content($"{{ \"message\": \"{message}\" }}", "application/json");
                }
                dynamic retVal = await authManager.VerifyOTP(model.Email, otp.OTP);
                if (retVal is int)
                {
                    string retValue = await authManager.UpdatePassord(user.Email, model.Password);
                    if (retValue.StartsWith("OK"))
                    {
                        string subject = "Password Changed Successfully";
                        string salutation = "Dear " + user.FirstName + " " + user.LastName;
                        string messageBody = $"<h1>Your Password changed recently thanks to be part of Emtiyaz </h1>";
                        string emailMessage = $"{subject}\n\n{salutation}\n\n{messageBody}";
                        await _emailService.SendEmailAsync(user.Email, subject, emailMessage);
                        bool res = await _passwordService.Delete(otp.Id);
                        if (res)
                        {
                            await _passwordService.CompleteAync();
                            message = "Your Password is  changed Successfully";
                            return Content($"{{ \"message\": \"{message}\" }}", "application/json");

                        }

                        return Content($"{{ \"message\": \"{retVal}\" }}", "application/json");
                    }

                    bool rese = await _passwordService.Delete(otp.Id);
                    await _passwordService.CompleteAync();
                    return Content($"{{ \"message\": \"{retVal}\" }}", "application/json");

                }
                bool resee = await _passwordService.Delete(otp.Id);
                await _passwordService.CompleteAync();
                message = "Your Password is  changed Successfully";
                return Content($"{{ \"message\": \"{retVal}\" }}", "application/json");
            }

            return BadRequest(ModelState);
        }

        private async Task<string> SendPasswordResetOTPEmailAsync(string to, string subject, string content)
        {

            await _emailService.SendEmailAsync(to, subject, content, isHtml: true);
            return "OK";
        }
        private async Task<string> StorePasswordResetRequest(PasswordResetDomain resetRequest)
        {

            try
            {

                await _passwordService.InsertAsync(resetRequest);
                await _passwordService.CompleteAync();
                var message = "OK";
                return message;

            }
            catch (Exception e)
            {

                throw new Exception(e.Message + e.InnerException?.Message);
            }



        }
        private static string GenerateRandomOTP(int length)
        {
            const string validChars = "0123456789";
            var random = new Random();
            var otp = new string(Enumerable.Repeat(validChars, length)
                .Select(s => s[random.Next(s.Length)])
                .ToArray());

            return otp;
        }
    }


}
