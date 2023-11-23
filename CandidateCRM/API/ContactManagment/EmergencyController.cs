using AutoMapper;
using ContactManagement;
using ERP.Common.Services;
using CandidateCRM.Controllers;
using Microsoft.AspNetCore.Mvc;
using ERP.ContactManagement.Model;
using ERP.CRM.ContactManagement.Service;

namespace CandidateCRM.API.ContactManagment
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmergencyController :ParentController<EmergencyContacts, EmergencyContactModel>
    {
        private readonly IEmergencyContact_Service _Service;
        private readonly IAuthManager            _authManager;
        public EmergencyController
        (
            IEmergencyContact_Service service,
            IMapper mapper,
            IAuthManager authManager
        ) : base(service, mapper)
        {
            _Service     = service;
            _authManager = authManager;
        }
    }
}
