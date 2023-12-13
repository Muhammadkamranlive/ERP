using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace ERP.DocumentManagement.Model
{
    public class AttachmentModel
    {
        public Guid Id              { get; set; }= Guid.NewGuid();
        public string userId        { get; set; }
        public string DocType       { get; set; }
        public string DocName       { get; set; }
        public string DocumentUrl   { get; set; }
    }
}
