using AutoMapper;
using System.Text;
using System.Text.Json;
using System.Security.Claims;
using CRM.Authentication.Model;
using ERP.TaskManagement.Model;
using ERP.Notifications.Domain;
using ERP.Notification.Service;
using ERP.Authentication.Domain;
using ERP.TaskManagement.Domain;
using ERP.Notifications.Repository;
using Microsoft.AspNetCore.Identity;
using System.Runtime.Intrinsics.X86;
using Microsoft.IdentityModel.Tokens;
using ERP.CRM.TaskManagement.Service;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.Extensions.Configuration;

namespace ERP.Common.Services
{
    public class AuthManager : IAuthManager
    {

        #region Fields
        private readonly IMapper                      _mapper;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IConfiguration               _configuration;
        private readonly RoleManager<IdentityRole>    _roleManager;
        private readonly IEmail_Service               _emailService;
        private readonly IPasswordReset_Service       _passwordResetService;
        private readonly IGeneralTask_Service         _generalTask_Service;
        private readonly INotifications_Service       _notifications_Service;
        #endregion

        #region Constructor
        public AuthManager
            (
            IMapper mapper,
            UserManager<ApplicationUser> userManager,
            IConfiguration configuration,
            RoleManager<IdentityRole> roleManager,
            IEmail_Service emailService,
            IPasswordReset_Service passwordResetService,
            IGeneralTask_Service generalTask_Service,
            INotifications_Service notifications_Service


            )
        {
            _mapper                = mapper;
            _userManager           = userManager;
            _configuration         = configuration;
            _roleManager           = roleManager;
            _emailService          = emailService;
            _passwordResetService  = passwordResetService;
            _generalTask_Service   = generalTask_Service;
            _notifications_Service = notifications_Service;

        }

        #endregion 

        public async Task<AuthResponseModel> Login(UserLoginModel loginDto)
        {
            var user            = await _userManager.FindByEmailAsync(loginDto.Email);
            if (user == null)
            {
                return new AuthResponseModel { Message = "User not found." };
            }
            bool isValidUser = await _userManager.CheckPasswordAsync(user, loginDto.Password);

            if (!isValidUser)
            {
                return new AuthResponseModel { Message = "Invalid credentials." };
            }
            var token = await GenerateToken(user);
            return new AuthResponseModel
            {
                Token       = token,
                UserId      = user.Id,
                EmailStatus = user.EmailConfirmed,
                Message     = "Success",

            };
        }
        public async Task<IEnumerable<IdentityError>> RegisterAdmin(RegisterUserModel adminDto)
        {
            try
            {
                var admin       = new ApplicationUser();
                admin.FirstName = adminDto.FirstName;
                admin.LastName  = adminDto.LastName;
                admin.MiddleName= adminDto.MiddleName;
                admin.Email     = adminDto.Email; ;
                admin.UserName  = adminDto.Email;
                
                var result = await _userManager.CreateAsync(admin, adminDto.Password);
                if (result.Succeeded)
                {
                    var roleExists = await _roleManager.RoleExistsAsync("Administrator");
                    if (!roleExists)
                    {
                        await _roleManager.CreateAsync(new IdentityRole("Administrator"));
                    }

                    await _userManager.AddToRoleAsync(admin, "Administrator");
                   
                }

                return result.Errors;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message + ex.InnerException?.Message);
            }
        }

        public async Task<IEnumerable<IdentityError>> RegisterCandidates(RegisterUserModel adminDto)
        {
            try
            {
                var admin       = new ApplicationUser();
                admin.FirstName = adminDto.FirstName;
                admin.LastName  = adminDto.LastName;
                admin.MiddleName = adminDto.MiddleName;
                admin.Email     = adminDto.Email; ;
                admin.UserName  = adminDto.Email;
                admin.image     = "https://firebasestorage.googleapis.com/v0/b/images-107c9.appspot.com/o/deafut.jpg?alt=media&token=b9fac53e-2606-44b3-89c2-e4bc03479051";


                var result = await _userManager.CreateAsync(admin, adminDto.Password);
                if (result.Succeeded)
                {
                    var roleExists = await _roleManager.RoleExistsAsync("Candidate");
                    if (!roleExists)
                    {
                        await _roleManager.CreateAsync(new IdentityRole("Candidate"));
                    }
                    await _userManager.AddToRoleAsync(admin, "Candidate");
                    var user = await _userManager.FindByNameAsync(admin.Email);

                    if (user != null)
                    {

                        var tasks = new List<GENERALTASK>
                        {
                            new GENERALTASK
                            {
                                Id          = Guid.NewGuid(),
                                Title       = "Personal Information",
                                Description = "Please Add Your Personal Information ",
                                StartDate   = DateTime.Now,
                                DueDate     = DateTime.Now.AddDays(7),
                                Type        = "Task",
                                Progress    = "Pending",
                                UserId      = user.Id
                            },
                            new GENERALTASK
                            {
                                Id          = Guid.NewGuid(),
                                Title       = "Emergency Contacts Information",
                                Description = "Please Add Your Emergency Contacts Information ",
                                StartDate   = DateTime.Now,
                                DueDate     = DateTime.Now.AddDays(7),
                                Type        = "Task",
                                Progress    = "Pending",
                                UserId      = user.Id
                            },
                            new GENERALTASK
                            {
                                Id          = Guid.NewGuid(),
                                Title       = "Dependents Information",
                                Description = "Please Add Your Dependents Information ",
                                StartDate   = DateTime.Now,
                                DueDate     = DateTime.Now.AddDays(7),
                                Type        = "Task",
                                Progress    = "Pending",
                                UserId      = user.Id
                            },
                            new GENERALTASK
                            {
                                Id          = Guid.NewGuid(),
                                Title       = "Education Information",
                                Description = "Please Add Your Education Information ",
                                StartDate   = DateTime.Now,
                                DueDate     = DateTime.Now.AddDays(7),
                                Type        = "Task",
                                Progress    = "Pending",
                                UserId      = user.Id
                            },
                            new GENERALTASK
                            {
                                Id          = Guid.NewGuid(),
                                Title       = "Professional License Information",
                                Description = "Please Add Your Professional License Information ",
                                StartDate   = DateTime.Now,
                                DueDate     = DateTime.Now.AddDays(7),
                                Type        = "Task",
                                Progress    = "Pending",
                                UserId      = user.Id
                            },
                            new GENERALTASK
                            {
                                Id          = Guid.NewGuid(),
                                Title       = "Job Experience Information",
                                Description = "Please Add Your Job History  ",
                                StartDate   = DateTime.Now,
                                DueDate     = DateTime.Now.AddDays(7),
                                Type        = "Task",
                                Progress    = "Pending",
                                UserId      = user.Id
                            },
                            new GENERALTASK
                            {
                                Id          = Guid.NewGuid(),
                                Title       = "Certifications Information",
                                Description = "Please Add Your Certifications Information ",
                                StartDate   = DateTime.Now,
                                DueDate     = DateTime.Now.AddDays(7),
                                Type        = "Task",
                                Progress    = "Pending",
                                UserId      = user.Id
                            },
                        };

                        await _generalTask_Service.AddRange(tasks);
                        await _generalTask_Service.CompleteAync();
                        var notification          = new NOTIFICATIONS();
                        notification.IsRead       = false;
                        notification.Message      = "Your Account Created Successfully";
                        notification.UserId       = user.Id;
                        notification.WorkflowStep = "Registration";
                        notification.Timestamp = DateTime.Now;
                        await _notifications_Service.InsertAsync(notification);
                        await _notifications_Service.CompleteAync();
                    }

                }

                return result.Errors;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message + ex.InnerException?.Message);
            }
        }

        public async Task<IEnumerable<IdentityError>> RegisterPatient(RegisterUserModel adminDto)
        {
            try
            {
                var admin = new ApplicationUser();
                admin.FirstName = adminDto.FirstName;
                admin.LastName = adminDto.LastName;
                admin.Email = adminDto.Email; ;
                admin.UserName = adminDto.Email;
               
                var result = await _userManager.CreateAsync(admin, adminDto.Password);
                if (result.Succeeded)
                {
                    var roleExists = await _roleManager.RoleExistsAsync("Candidate");
                    if (!roleExists)
                    {
                        await _roleManager.CreateAsync(new IdentityRole("Candidate"));
                    }
                    await _userManager.AddToRoleAsync(admin, "Candidate");
                }

                return result.Errors;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message + ex.InnerException?.Message);
            }
        }

        public async Task<IEnumerable<IdentityError>> RegisterHospital(RegisterUserModel adminDto)
        {
            try
            {
                var admin       = new ApplicationUser();
                admin.FirstName = adminDto.FirstName;
                admin.LastName  = adminDto.LastName;
                admin.Email     = adminDto.Email; ;
                admin.UserName  = adminDto.Email;
               
                var result      = await _userManager.CreateAsync(admin, adminDto.Password);
                if (result.Succeeded)
                {
                    var roleExists = await _roleManager.RoleExistsAsync("Hospital");
                    if (!roleExists)
                    {
                        await _roleManager.CreateAsync(new IdentityRole("Hospital"));
                    }
                    await _userManager.AddToRoleAsync(admin, "Hospital");
                }

                return result.Errors;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message + ex.InnerException?.Message);
            }
        }
        public async Task<dynamic> FindById(string uid)
        {
            try
            {
                var user = await _userManager.FindByIdAsync(uid);
                return user;
            }
            catch (Exception ex)
            {
                return ex.Message + ex.InnerException?.Message;
            }
        }
        public async Task<dynamic> UpdateUser(UpdateUserModel user)
        {
            try
            {
                ApplicationUser user1 = await _userManager.FindByEmailAsync(user.Email);
                if (user1 == null)
                {
                    var message = "No User Found Against Email " + user.Email;
                    return JsonSerializer.Serialize(message);
                }

                user1.FirstName  = user.FirstName;
                user1.LastName   = user.LastName;
                user1.MiddleName = user.MiddleName;
                user1.image      = user.Image;
                var result = await _userManager.UpdateAsync(user1);
                if (result.Succeeded == true)
                {
                    var notification = new NOTIFICATIONS();
                    notification.IsRead = false;
                    notification.Message = "Your Account Detail Updated Successfully";
                    notification.UserId = user1.Id;
                    notification.Timestamp = DateTime.Now;
                    notification.WorkflowStep = "Account Setting";
                    await _notifications_Service.InsertAsync(notification);
                    await _notifications_Service.CompleteAync();
                    var message       = "User neccessary Details Updated Successfully";
                    return JsonSerializer.Serialize(message);
                }
                return user;
            }
            catch (Exception ex)
            {
                return ex.Message + ex.InnerException?.Message;
            }
        }
        public async Task<dynamic> FindbyEmail(string email)
        {
            return await _userManager.FindByEmailAsync(email);
        }
        public async Task<dynamic> UpdatePassord(string email, string password)
        {
            var user = await _userManager.FindByEmailAsync(email);
            if (user != null)
            {
                var token  = await _userManager.GeneratePasswordResetTokenAsync(user);
                var result = await _userManager.ResetPasswordAsync(user, token, password);
                if (result.Succeeded)
                {
                    var notification = new NOTIFICATIONS();
                    notification.IsRead = false;
                    notification.Message = "Your Password Detail Updated Successfully";
                    notification.UserId = user.Id;
                    notification.Timestamp = DateTime.Now;
                    notification.WorkflowStep = "Password Update";
                    await _notifications_Service.InsertAsync(notification);
                    await _notifications_Service.CompleteAync();
                    return "OK Password updated successfully";
                }
                else
                {
                    var errors = result.Errors.Select(e => e.Description).FirstOrDefault();
                }
            }
            return "User not Found";
        }
        public async Task<dynamic> ComfirmEmail(string email, string otp)
        {
            try
            {
                var currentTime = DateTime.Now;
                ApplicationUser user = await _userManager.FindByEmailAsync(email);
                if (user == null)
                {
                    return "User not Found";
                }
                dynamic retVlaue = await VerifyOTP(email, otp);
                if (retVlaue is Guid)
                {
                    user.EmailConfirmed = true;
                    await _userManager.UpdateAsync(user);
                    string subject      = "Email Confirmed Successfully";
                    string salutation   = "Dear " + user.FirstName + " " + user.LastName;
                    string messageBody  = $"<h1>Your Email confirmed Successfully thanks to be part of Sapient Medical  </h1>";
                    string emailMessage = $"{subject}\n\n{salutation}\n\n{messageBody}";
                    await _emailService.SendEmailAsync(user.Email, subject, emailMessage);
                    var res             = await _passwordResetService.Delete(retVlaue);
                    if (res)
                    {
                        await _passwordResetService.CompleteAync();
                        var notification = new NOTIFICATIONS();
                        notification.IsRead = false;
                        notification.Message = "Your Emai Confirmed Successfully";
                        notification.UserId = user.Id;
                        notification.Timestamp = DateTime.Now;
                        notification.WorkflowStep = "Email Confirmation";
                        await _notifications_Service.InsertAsync(notification);
                        await _notifications_Service.CompleteAync();
                        return "Your Email Confirmed Successfully";
                    }

                    return res;
                }
                return retVlaue;



            }
            catch (Exception ex)
            {

                return ex.Message + ex.InnerException?.Message;
            }
        }
        public async Task<dynamic> SendComfirmEmail(string email)
        {
            try
            {
                ApplicationUser user = await _userManager.FindByEmailAsync(email);
                if (user == null)
                {
                    return "User not found";
                }
                var otp            = GenerateRandomOTP();
                var expirationTime = DateTime.Now.AddMinutes(15);
                var resetRequest   = new PasswordResetDomain
                {
                    Email          = user.Email,
                    ExpireTime     = expirationTime,
                    OTP            = otp
                };

                string retValue = await StorePasswordResetRequest(resetRequest);
                if (!retValue.StartsWith("OK"))
                {
                    return retValue;
                }
                string subject = "Verify Email";
                string salutation = "Dear" + " " + user.FirstName + " " + user.LastName;
                string messageBody = $"\r\n\r\n\n\n\nThank you for registering with Emtiyaz.\r\n\r\nEmail Verification OTP\r\n\r\n\n\n\n:<h1>{otp}</h1>";

                string emailMessage = $"\r\n\r\n\n<h1>{salutation}</h1>\r\n\r\n\n\n\n{messageBody}";
                await _emailService.SendEmailAsync(user.Email, subject, emailMessage, true);
                var notification = new NOTIFICATIONS();
                notification.IsRead = false;
                notification.Message = "Email Cnfirmation sent Successfully";
                notification.UserId = user.Id;
                notification.Timestamp = DateTime.Now;
                notification.WorkflowStep = "Email Confirmation";
                await _notifications_Service.InsertAsync(notification);
                await _notifications_Service.CompleteAync();
                return "Email has been sent to You for Verification";
            }
            catch (Exception ex)
            {

                return ex.Message + ex.InnerException?.Message;
            }
        }
        public async Task<dynamic> VerifyOTP(string email, string otp)
        {
            var currentTime = DateTime.Now;
            IList<PasswordResetDomain> otplist = (IList<PasswordResetDomain>)await _passwordResetService.GetAll();
            if (otplist.Count == 0)
            {
                return "You did not have generated OTP";
            }
            PasswordResetDomain otpf = otplist.Where(x => x.Email == email).OrderBy(x => x.ExpireTime).LastOrDefault();
            if (currentTime <= otpf.ExpireTime && otpf.OTP == otp)
            {
                return otpf.Id;
            }

            return "OTP expired generate new ";
        }
        private async Task<string> StorePasswordResetRequest(PasswordResetDomain resetRequest)
        {

            try
            {

                await _passwordResetService.InsertAsync(resetRequest);
                await _passwordResetService.CompleteAync();
                var message = "OK";
                return message;

            }
            catch (Exception e)
            {

                throw new Exception(e.Message + e.InnerException?.Message);
            }



        }
        private static string      GenerateRandomOTP()
        {
            const string validChars = "0123456789";
            int leng = 8;
            var random = new Random();
            var otp = new string(Enumerable.Repeat(validChars, leng)
                .Select(s => s[random.Next(s.Length)])
                .ToArray());

            return otp;
        }
        private async Task<string> GenerateToken(ApplicationUser user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JwtSettings:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var roles = await _userManager.GetRolesAsync(user);
            var roleClaims = roles.Select(x => new Claim(ClaimTypes.Role, x)).ToList();

            var userClaims = await _userManager.GetClaimsAsync(user);

            var claims = new List<Claim>
            {
              new Claim(JwtRegisteredClaimNames.Sub, user.Email),
              new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
              new Claim(JwtRegisteredClaimNames.Email, user.Email),
              new Claim("uid", user.Id),
              new Claim("EmailConfirmed", user.EmailConfirmed ? "true" : "false"),

            }
            .Union(userClaims)
            .Union(roleClaims);

            var token = new JwtSecurityToken(
                issuer: _configuration["JwtSettings:Issuer"],
                audience: _configuration["JwtSettings:Audience"],
                claims: claims,
                expires: DateTime.Now.AddMinutes(Convert.ToInt32(_configuration["JwtSettings:DurationInMinutes"])),
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

    }
}
