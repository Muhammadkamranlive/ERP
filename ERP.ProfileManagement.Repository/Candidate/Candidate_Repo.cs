using System;
using System.Linq;
using System.Text;
using ERP.DataBase;
using System.Threading.Tasks;
using ERP.Core.BusinessAccess;
using System.Collections.Generic;
using ERP.ProfileManagement.Domain;

namespace ERP.ProfileManagement.Repository
{
    public class Candidate_Repo:Repo<CandidateInfo>,ICandidate_Repo
    {
        private readonly ERPDb _db;
        public Candidate_Repo(ERPDb db):base(db) 
        {
            _db = db;
        }
    }
}
