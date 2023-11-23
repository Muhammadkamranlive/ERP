using ERP.Core.DataAccess;
using ERP.Core.ServiceAccess;
using ERP.ProfileManagement.Domain;
using ERP.ProfileManagement.Repository;

namespace ERP.ProfileManagement.Service
{
    public class Profile_Service:Base_Service<Personal>,IProfile_Service
    {
        public Profile_Service(IUnitOfWork unitOfWork, IPersonal_Repo _Repo) : base(unitOfWork, _Repo)
        {

        }
    }
}
