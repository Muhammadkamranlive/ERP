using ERP.Core.DataAccess;
using ERP.Core.ServiceAccess;
using ERP.Notifications.Domain;
using ERP.Notifications.Repository;

namespace ERP.Notification.Service
{
    public class Notifications_Service:Base_Service<NOTIFICATIONS>, INotifications_Service
    {
        public Notifications_Service(IUnitOfWork unitOfWork, INotifications_Repo _Repo) : base(unitOfWork, _Repo)
        {

        }
    }
}
