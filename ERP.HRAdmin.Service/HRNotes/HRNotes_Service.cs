using ERP.Core.DataAccess;
using ERP.Core.ServiceAccess;
using ERP.HRAdminStaff.Domain;
using ERP.HRAdminSttaf.Repository;

namespace ERP.HRAdmin.Service
{
    public class HRNotes_Service:Base_Service<HRNotes>, IHRNotes_Service
    {
        public HRNotes_Service(IUnitOfWork unitOfWork, IHRNotes_Repo _Repo) : base(unitOfWork, _Repo)
        {

        }
    }
}
