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
    public class ContactController : ParentController<CONTACTDETAILS, ContactDetailModel>
    {
        private readonly IContactDetails_Service _Service;
        private readonly IAuthManager           _authManager;
        public ContactController
        (
            IContactDetails_Service service,
            IMapper mapper,
            IAuthManager authManager
        ) : base(service, mapper)
        {
            _Service     = service;
            _authManager = authManager;
        }
    }
}
