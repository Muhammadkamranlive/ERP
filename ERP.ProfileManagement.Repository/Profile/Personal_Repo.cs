using ERP.DataBase;
using ERP.Core.BusinessAccess;
using ERP.ProfileManagement.Domain;

namespace ERP.ProfileManagement.Repository
{
    public class Personal_Repo:Repo<Personal>,IPersonal_Repo
    {
        private readonly ERPDb _db;
        public Personal_Repo(ERPDb db):base(db) 
        {
            _db = db;
        }
    }
}
