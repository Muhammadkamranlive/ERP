using ERP.Core.DataAccess;
using ERP.Core.ServiceAccess;
using ERP.CaseManagement.Domain;
using ERP.CustomerCare.Repository;

namespace ERP.CRM.CaseManagement.Service
{
    public class CaseManagment_Service:Base_Service<Case>, ICaseManagment_Service
    {
        public CaseManagment_Service(IUnitOfWork unitOfWork, ICase_Repo _Repo) : base(unitOfWork, _Repo)
        {

        }
    }
}
