using AutoMapper;
using ERP.Common.Services;
using CandidateCRM.Controllers;
using Microsoft.AspNetCore.Mvc;
using ERP.TaskManagement.Domain;
using ERP.CRM.TaskManagement.Service;

namespace CandidateCRM.API.TaskManagement
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskManagerController : ParentController<GENERALTASK, GENERALTASK>
    {
        private readonly IGeneralTask_Service _Service;
        private readonly IAuthManager         _authManager;
        public TaskManagerController
        (
            IGeneralTask_Service service,
            IMapper mapper,
            IAuthManager authManager
        ) : base(service, mapper)
        {
            _Service = service;
            _authManager = authManager;
        }
    }
}
