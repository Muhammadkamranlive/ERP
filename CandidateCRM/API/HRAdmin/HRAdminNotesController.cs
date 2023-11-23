using AutoMapper;
using ERP.Common.Services;
using ERP.HRAdmin.Service;
using ERP.HRAdminStaff.Model;
using ERP.HRAdminStaff.Domain;
using CandidateCRM.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace CandidateCRM.API.HRAdmin
{
    [Route("api/[controller]")]
    [ApiController]
    public class HRAdminNotesController : ParentController<HRNotes, HRNoteModel>
    {
        private readonly IHRNotes_Service       _Service;
        private readonly IAuthManager           _authManager;
        public HRAdminNotesController
        (
            IHRNotes_Service service,
            IMapper mapper,
            IAuthManager authManager
        ) : base(service, mapper)
        {
            _Service = service;
            _authManager = authManager;
        }
    }
}
