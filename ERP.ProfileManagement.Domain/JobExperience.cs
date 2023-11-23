﻿using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace ERP.ProfileManagement.Domain
{
    public class JobExperience
    {
        public Guid     Id                     { get; set; }
        public string   userId                { get; set; }
        public string   PreviousCompany        { get; set; }
        public string   PreviousCompanyAddress { get; set; }
        public string   JobTitle               { get; set; }
        public string   Status                 { get; set; }
        public DateTime FromDate               { get; set; }
        public DateTime ToDate                 { get; set; }
        public string   JobDescription         { get; set; }
        public string   ReasonForLeaving       { get; set; }
    }

    
}
