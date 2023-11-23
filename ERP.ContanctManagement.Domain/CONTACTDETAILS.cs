using ERP.Authentication.Domain;

namespace ContactManagement
{
    public class CONTACTDETAILS
    {
        public Guid   Id            { get; set; }
        public string userId        { get; set; }
        public ApplicationUser User { get; set; }
        public string HomePhone     { get; set; }
        public string MobilePhone   { get; set; }
        public string Carrier       { get; set; }
        public string PersonalEmail { get; set; }
    }
}