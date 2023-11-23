using ERP.DataBase;
using ERP.HRAdminStaff.Domain;
using ERP.Core.BusinessAccess;

namespace ERP.HRAdminSttaf.Repository
{
    public class HRNotes_Repo:Repo<HRNotes>, IHRNotes_Repo
    {
        private readonly ERPDb _db;
        public HRNotes_Repo(ERPDb db):base(db)
        {
            _db = db;
        }
    }
}
