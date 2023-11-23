using System;
using System.Linq;
using System.Text;
using ERP.DataBase;
using System.Threading.Tasks;
using ERP.Core.BusinessAccess;
using System.Collections.Generic;
using ERP.DocumentManagement.Domain;

namespace ERP.DocumentManagement.Repository
{
    public class Attachments_Repo:Repo<Attachments>, IAttachments_Repo
    {
        private readonly ERPDb _db;
        public Attachments_Repo(ERPDb DB):base(DB) 
        {
            _db = DB;
        }
    }
}
