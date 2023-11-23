using ERP.Core.DataAccess;
using ERP.Core.ServiceAccess;
using ERP.ProfileManagement.Domain;
using ERP.ProfileManagement.Repository;

namespace ERP.ProfileManagement.Service
{
    public class Educations_Service:Base_Service<Education>, IEducations_Service
    {
        public Educations_Service(IUnitOfWork unitOfWork, IEducation_Repo _Repo) : base(unitOfWork, _Repo)
        {

        }
    }
}
