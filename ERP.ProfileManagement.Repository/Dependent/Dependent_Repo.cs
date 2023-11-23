using System;
using System.Linq;
using System.Text;
using ERP.DataBase;
using System.Threading.Tasks;
using ERP.Core.BusinessAccess;
using System.Collections.Generic;
using ERP.ProfileManagement.Domain;

namespace ERP.ProfileManagement.Repository
{
    public class Dependent_Repo:Repo<Dependent>, IDependent_Repo
    {
        private readonly ERPDb _db;
        public Dependent_Repo(ERPDb db) : base(db)
        {
            _db = db;
        }
    }
}
