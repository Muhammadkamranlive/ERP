using System;
using System.Linq;
using System.Text;
using ERP.Core.DataAccess;
using System.Threading.Tasks;
using ERP.Core.ServiceAccess;
using ERP.Authentication.Domain;
using System.Collections.Generic;
using CRM.Authentication.Repository;

namespace ERP.Common.Services
{
    public class PasswordReset_Service : Base_Service<PasswordResetDomain>, IPasswordReset_Service
    {
        public PasswordReset_Service(IUnitOfWork unitOfWork, IPasswordReset_Repo _Repo) : base(unitOfWork, _Repo)
        {

        }
    }
}
