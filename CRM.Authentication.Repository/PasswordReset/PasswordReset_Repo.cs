using ERP.DataBase;
using ERP.Core.BusinessAccess;
using ERP.Authentication.Domain;

namespace CRM.Authentication.Repository
{
    public class PasswordReset_Repo : Repo<PasswordResetDomain>, IPasswordReset_Repo
    {
        public PasswordReset_Repo(ERPDb db) : base(db)
        {

        }
    }
}