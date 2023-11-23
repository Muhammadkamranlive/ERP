using ERP.DataBase;
using ERP.Core.BusinessAccess;
using ERP.Notifications.Domain;

namespace ERP.Notifications.Repository
{
    public class Notifications_Repo:Repo<NOTIFICATIONS>, INotifications_Repo
    {
        private readonly ERPDb _db;
        public Notifications_Repo(ERPDb db):base(db) 
        {
            _db = db;
        }
    }
}
