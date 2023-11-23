﻿namespace ERP.Authentication.Domain
{
    public class PasswordResetDomain
    {
        public Guid      Id         { get; set; }
        public string   Email      { get; set; }
        public string   OTP        { get; set; }
        public DateTime ExpireTime { get; set; }
    }
}