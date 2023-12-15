using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ERP.Authentication.Domain;
using System.Collections.Generic;

namespace ERP.DocumentManagement.Domain
{
    public class Attachments
    {
        public Guid Id              { get; set; }
        public string userId        { get; set; }
        public string DocType       { get; set; }
        public string DocName       { get; set; }
        public string DocumentUrl   { get; set; }
        public string? SenderId     { get; set; } 
        public string? ReceiverId   { get; set; }  
        public string? Status       { get; set; } 

    }
}
