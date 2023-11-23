using System.Threading.Tasks;
using ERP.Authentication.Domain;

namespace ERP.CaseManagement.Domain
{
    public class Case
    {
        public Guid Id                            { get; set; }
        public string Title                       { get; set; }
        public string Description                 { get; set; }
        public DateTime CreatedAt                 { get; set; } = DateTime.UtcNow;
        public string   Status                    { get; set; } = "Open";
        public string CustomerId                  { get; set; } 
        public ApplicationUser Customer           { get; set; } 
        public string AgentId                     { get; set; } 
        public ApplicationUser AssignedAgent      { get; set; } 
        public ICollection<CaseComment> Comments  { get; set; } = new List<CaseComment>();
    }

    
}