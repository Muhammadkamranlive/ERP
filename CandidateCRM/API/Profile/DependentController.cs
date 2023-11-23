using AutoMapper;
using ERP.Common.Services;
using CandidateCRM.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using ERP.ProfileManagement.Model;
using ERP.ProfileManagement.Domain;
using ERP.ProfileManagement.Service;

namespace CandidateCRM.API.Profile
{
    [Route("api/[controller]")]
    [ApiController]
    public class DependentController : ParentController<Dependent, DependentModel>
    {
        private readonly IDependent_Service _Service;
        private readonly IAuthManager _authManager;
        public DependentController
        (
            IDependent_Service service,
            IMapper mapper,
            IAuthManager authManager
        ) : base(service, mapper)
        {
            _Service = service;
            _authManager = authManager;
        }
    }
}
