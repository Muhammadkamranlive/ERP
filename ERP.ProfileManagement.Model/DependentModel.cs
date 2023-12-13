﻿using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace ERP.ProfileManagement.Model
{
    public class DependentModel
    {
        public Guid Id              { get; set; } = Guid.NewGuid();
        public string userId        { get; set; }
        public string Name          { get; set; }
        public string Relationship  { get; set; }
        public DateTime DateOfBirth { get; set; }
        public bool HasSpecialNeeds { get; set; }
        public string Notes         { get; set; }
    }
}
