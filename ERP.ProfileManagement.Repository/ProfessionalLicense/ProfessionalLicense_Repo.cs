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
    public class ProfessionalLicense_Repo:Repo<ProfessionalLicense>, IProfessionalLicense_Repo
    {
        private readonly ERPDb _db;
        public ProfessionalLicense_Repo(ERPDb db):base(db) 
        {
            _db = db;
        }
    }
}
