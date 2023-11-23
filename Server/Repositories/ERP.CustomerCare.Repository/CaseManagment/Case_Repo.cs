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
    public class Case_Repo:Repo<Case>, ICase_Repo
    {
        private readonly ERPDb _db;
        public Case_Repo(ERPDb eRP):base(eRP) 
        {
            _db = eRP;   
        }
    }
}
