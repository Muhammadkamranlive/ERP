using System;
using System.Linq;
using System.Text;
using ERP.Core.DataAccess;
using ERP.Core.ServiceAccess;
using System.Threading.Tasks;
using System.Collections.Generic;
using ERP.ProfileManagement.Domain;
using ERP.ProfileManagement.Repository;

namespace ERP.ProfileManagement.Service
{
    public class Dependent_Service:Base_Service<Dependent>, IDependent_Service
    {
        public Dependent_Service(IUnitOfWork unitOfWork, IDependent_Repo _Repo) : base(unitOfWork, _Repo)
        {

        }
    }
}
