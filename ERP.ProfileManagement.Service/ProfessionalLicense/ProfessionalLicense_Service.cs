using ERP.Core.DataAccess;
using ERP.Core.ServiceAccess;
using ERP.ProfileManagement.Domain;
using ERP.ProfileManagement.Repository;

namespace ERP.ProfileManagement.Service
{
    public class ProfessionalLicense_Service:Base_Service<ProfessionalLicense>, IProfessionalLicense_Service
    {
        public ProfessionalLicense_Service(IUnitOfWork unitOfWork, IProfessionalLicense_Repo _Repo) : base(unitOfWork, _Repo)
        {

        }
    }
}
