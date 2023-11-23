using System;
using System.Linq;
using System.Text;
using ERP.DataBase;
using System.Threading.Tasks;
using ERP.Core.BusinessAccess;
using ERP.CaseManagement.Domain;
using System.Collections.Generic;

namespace ERP.CustomerCare.Repository
{
    public class CaseCommetns_Repo:Repo<CaseComment>, ICaseCommetns_Repo
    {
        private readonly ERPDb eRPDb;
        public CaseCommetns_Repo(ERPDb db):base(db)
        {
                eRPDb = db;
        }
    }
}
