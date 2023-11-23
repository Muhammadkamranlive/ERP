using ERP.Core.DataAccess;
using ERP.Core.ServiceAccess;
using ERP.TaskManagement.Domain;
using ERP.TaskManagement.Repository;

namespace ERP.CRM.TaskManagement.Service
{
    public class GeneralTask_Service:Base_Service<GENERALTASK>, IGeneralTask_Service
    {
        public GeneralTask_Service(IUnitOfWork unitOfWork, IGeneralTask_Repo _Repo) : base(unitOfWork, _Repo)
        {

        }
    }
}
