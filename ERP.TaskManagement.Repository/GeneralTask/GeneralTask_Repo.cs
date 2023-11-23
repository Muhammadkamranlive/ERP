using ERP.DataBase;
using ERP.Core.BusinessAccess;
using ERP.TaskManagement.Domain;

namespace ERP.TaskManagement.Repository
{
    public class GeneralTask_Repo:Repo<GENERALTASK>, IGeneralTask_Repo
    {
        private readonly ERPDb _Db;
        public GeneralTask_Repo(ERPDb db):base(db) 
        {
            _Db = db;
        }
    }
}
