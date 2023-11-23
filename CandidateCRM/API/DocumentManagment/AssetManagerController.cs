using AutoMapper;
using ERP.Common.Services;
using CandidateCRM.Controllers;
using Microsoft.AspNetCore.Mvc;
using ERP.DocumentManagement.Model;
using ERP.DocumentManagement.Domain;
using ERP.CRM.DocumentManagement.Service;

namespace CandidateCRM.API.DocumentManagment
{
    [Route("api/[controller]")]
    [ApiController]
    public class AssetManagerController : ParentController<Asset, AssetModel>
    {
        private readonly IAssetManager_Service   _Service;
        private readonly IAuthManager            _authManager;
        public AssetManagerController
        (
            IAssetManager_Service service,
            IMapper mapper,
            IAuthManager  authManager
        ) : base(service, mapper)
        {
            _Service = service;
            _authManager = authManager;
        }
    }
}
