using ERP.Core.DataAccess;
using ERP.Core.ServiceAccess;
using ERP.ProfileManagement.Domain;
using ERP.ProfileManagement.Repository;

namespace ERP.ProfileManagement.Service
{
    public class JobExperience_Service:Base_Service<JobExperience>, IJobExperience_Service
    {
        public JobExperience_Service(IUnitOfWork unitOfWork, IJobExperience_Repo _Repo) : base(unitOfWork, _Repo)
        {

        }
    }
}
