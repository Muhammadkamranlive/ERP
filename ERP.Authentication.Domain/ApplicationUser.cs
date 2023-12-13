using Microsoft.AspNetCore.Identity;

namespace ERP.Authentication.Domain
{
    public class ApplicationUser : IdentityUser
    {
        public string  FirstName            { get; set; }
        public string? MiddleName           { get; set; }
        public string  LastName             { get; set; }
        public string? image                { get; set; }
        public bool?   personal             { get; set; }
        public bool?   EmergencyContact     { get; set; }
        public bool?   Education            { get; set; }
        public bool?   ProfessionalLicense  { get; set; }
        public bool?   JobExp               { get; set; }
        public bool?   Dependents           { get; set; }
        public bool?   FileManager          { get; set; }
        public bool?   Asset                { get; set; }

    }
}