using System;
using System.Linq;
using System.Text;
using ERP.Core.DataAccess;
using System.Threading.Tasks;
using ERP.Core.ServiceAccess;
using ERP.CaseManagement.Domain;
using System.Collections.Generic;
using ERP.CustomerCare.Repository;

namespace ERP.CRM.CaseManagement.Service
{
    public class CaseComments_Service:Base_Service<CaseComment>, ICaseComments_Service
    {
        public CaseComments_Service(IUnitOfWork unitOfWork, ICaseCommetns_Repo _Repo) : base(unitOfWork, _Repo)
        {

        }
    }
}
