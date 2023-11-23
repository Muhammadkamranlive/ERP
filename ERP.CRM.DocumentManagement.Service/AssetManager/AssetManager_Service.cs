using System;
using System.Linq;
using System.Text;
using ERP.Core.DataAccess;
using ERP.Core.ServiceAccess;
using System.Threading.Tasks;
using System.Collections.Generic;
using ERP.DocumentManagement.Domain;
using ERP.DocumentManagement.Repository;

namespace ERP.CRM.DocumentManagement.Service
{
    public class AssetManager_Service:Base_Service<Asset>, IAssetManager_Service
    {
        public AssetManager_Service(IUnitOfWork unitOfWork, IAssetManager_Repo _Repo) : base(unitOfWork, _Repo)
        {

        }
    }
}
