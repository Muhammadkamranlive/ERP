using ERP.Authentication.Domain;

namespace ERP.TaskManagement.Domain
{
    public class GENERALTASK
    {
        public Guid     Id                     { get; set; }
        public string   Title                  { get; set; }
        public string   Description            { get; set; }
        public DateTime StartDate              { get; set; }
        public DateTime DueDate                { get; set; }
        public string   Type                   { get; set; }
        public string   UserId                 { get; set; }
        public string   Progress               { get; set; }

    }
}
