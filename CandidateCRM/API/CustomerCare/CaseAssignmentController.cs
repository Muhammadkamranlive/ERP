using AutoMapper;
using ERP.Common.Services;
using ERP.CustomerCare.Model;
using CandidateCRM.Controllers;
using Microsoft.AspNetCore.Mvc;
using ERP.CaseManagement.Domain;
using ERP.CRM.CaseManagement.Service;

namespace CandidateCRM.API.CustomerCare
{
    [Route("api/[controller]")]
    [ApiController]
    public class CaseAssignmentController : ParentController<CaseComment, CaseCommentModel>
    {
        private readonly ICaseComments_Service  _Service;
        private readonly IAuthManager           _authManager;
        public CaseAssignmentController
        (
            ICaseComments_Service service,
            IMapper mapper,
            IAuthManager authManager
        ) : base(service, mapper)
        {
            _Service = service;
            _authManager = authManager;
        }
    }
}
