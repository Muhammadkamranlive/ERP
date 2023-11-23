﻿using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ERP.Authentication.Domain;
using System.Collections.Generic;

namespace ERP.CaseManagement.Domain
{
    public class CaseComment
    {
        public Guid Id               { get; set; }
        public string Text           { get; set; }
        public DateTime CreatedAt    { get; set; } = DateTime.UtcNow;
        public Guid CaseId            { get; set; }
        public string UserId         { get; set; } 
        
    }
}
