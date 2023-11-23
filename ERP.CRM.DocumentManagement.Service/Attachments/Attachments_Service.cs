using ERP.Core.DataAccess;
using ERP.Core.ServiceAccess;
using ERP.DocumentManagement.Domain;
using ERP.DocumentManagement.Repository;

namespace ERP.CRM.DocumentManagement.Service
{
    public class Attachments_Service:Base_Service<Attachments>, IAttachments_Service
    {
        public Attachments_Service(IUnitOfWork unitOfWork, IAttachments_Repo _Repo) : base(unitOfWork, _Repo)
        {

        }
    }
}
