using ContactManagement;
using ERP.Core.DataAccess;
using ERP.Core.ServiceAccess;
using ERP.ContactManagement.Repository;

namespace ERP.CRM.ContactManagement.Service
{
    public class ContactDetails_Service:Base_Service<CONTACTDETAILS>, IContactDetails_Service
    {
        public ContactDetails_Service(IUnitOfWork unitOfWork, IContactDetails_Repo _Repo) : base(unitOfWork, _Repo)
        {

        }
    }
}
