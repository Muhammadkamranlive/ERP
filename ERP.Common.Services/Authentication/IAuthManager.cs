using System;
using System.Linq;
using System.Text;
using System.Collections;
using System.Threading.Tasks;
using CRM.Authentication.Model;
using ERP.Authentication.Domain;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace ERP.Common.Services
{
    public interface IAuthManager
    {
        Task<AuthResponseModel> Login(UserLoginModel loginDto);
        Task<IEnumerable<IdentityError>> RegisterAdmin(RegisterUserModel adminDto);
        Task<IEnumerable<IdentityError>> RegisterCandidates(RegisterUserModel adminDto);
        Task<IEnumerable<IdentityError>> RegisterPatient(RegisterUserModel adminDto);
        Task<IEnumerable<IdentityError>> RegisterHospital(RegisterUserModel adminDto);
        Task<dynamic> FindById(string uid);
        Task<dynamic> UpdateUser(UpdateUserModel user);
        Task<dynamic> FindbyEmail(string email);
        Task<dynamic> UpdatePassord(string email, string password);
        Task<dynamic> ComfirmEmail(string email, string otp);
        Task<dynamic> SendComfirmEmail(string email);
        Task<dynamic> VerifyOTP(string email, string otp);

    }
}
