using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace ERP.ProfileManagement.Domain
{
    public class Dependent
    {
        public Guid Id              { get; set; }
        public Guid userId          { get; set; }
        public string Name          { get; set; }
        public string Relationship  { get; set; }
        public DateTime DateOfBirth { get; set; }
        public bool HasSpecialNeeds { get; set; }
        public string Notes         { get; set; }
    }
}
