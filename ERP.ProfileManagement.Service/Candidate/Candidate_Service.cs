using ERP.Core.DataAccess;
using ERP.Core.ServiceAccess;
using ERP.ProfileManagement.Domain;
using ERP.ProfileManagement.Repository;

namespace ERP.ProfileManagement.Service
{
    public class Candidate_Service:Base_Service<CandidateInfo>, ICandidate_Service
    {
        public Candidate_Service(IUnitOfWork unitOfWork, ICandidate_Repo _Repo) : base(unitOfWork, _Repo)
        {

        }
    }
}
