using System;
using System.Linq;
using System.Text;
using ERP.DataBase;
using System.Threading.Tasks;
using ERP.Core.BusinessAccess;
using System.Collections.Generic;
using ERP.DocumentManagement.Domain;

namespace ERP.DocumentManagement.Repository
{
    public class AssetManager_Repo:Repo<Asset>, IAssetManager_Repo
    {
        private readonly ERPDb eRPDb;
        public AssetManager_Repo(ERPDb db):base(db) 
        {
            eRPDb = db;
        }
    }
}
