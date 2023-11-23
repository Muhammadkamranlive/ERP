using AutoMapper;
using ERP.Common.Services;
using CandidateCRM.Controllers;
using Microsoft.AspNetCore.Mvc;
using ERP.ProfileManagement.Model;
using ERP.ProfileManagement.Domain;
using ERP.ProfileManagement.Service;

namespace CandidateCRM.API.Profile
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfessionalLicenseController : ParentController<ProfessionalLicense,ProfessionalLicenseModel>
    {
        private readonly IProfessionalLicense_Service _Service;
        private readonly IAuthManager                _authManager;
        public ProfessionalLicenseController
        (
            IProfessionalLicense_Service service,
            IMapper                      mapper,
            IAuthManager                 authManager
        ) : base(service, mapper)
        {
            _Service = service;
            _authManager = authManager;
        }
    }
}
