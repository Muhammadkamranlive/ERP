using AutoMapper;
using ERP.Common.Services;
using ERP.Notifications.Model;
using CandidateCRM.Controllers;
using ERP.Notification.Service;
using ERP.Notifications.Domain;
using Microsoft.AspNetCore.Mvc;

namespace CandidateCRM.API.Notifications
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationController : ParentController<NOTIFICATIONS, NotificationsModel>
    {
        private readonly INotifications_Service _Service;
        private readonly IAuthManager           _authManager;
        public NotificationController
        (
            INotifications_Service service,
            IMapper mapper,
            IAuthManager authManager
        ) : base(service, mapper)
        {
            _Service = service;
            _authManager = authManager;
        }
    }
}
