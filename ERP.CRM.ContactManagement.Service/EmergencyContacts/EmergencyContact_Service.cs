using ContactManagement;
using ERP.Core.DataAccess;
using ERP.Core.ServiceAccess;
using ERP.ContactManagement.Repository;

namespace ERP.CRM.ContactManagement.Service
{
    public class EmergencyContact_Service:Base_Service<EmergencyContacts>, IEmergencyContact_Service
    {

        public EmergencyContact_Service(IUnitOfWork unitOfWork, IEmergencyContacts_Repo _Repo) : base(unitOfWork, _Repo)
        {

        }
    }
}
