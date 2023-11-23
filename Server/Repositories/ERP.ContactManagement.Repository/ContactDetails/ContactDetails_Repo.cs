using System;
using System.Linq;
using System.Text;
using ERP.DataBase;
using ContactManagement;
using System.Threading.Tasks;
using ERP.Core.BusinessAccess;
using System.Collections.Generic;

namespace ERP.ContactManagement.Repository
{
    public class ContactDetails_Repo:Repo<CONTACTDETAILS>, IContactDetails_Repo
    {
        private readonly ERPDb _db;
        public ContactDetails_Repo(ERPDb db):base(db) 
        {
                _db = db;
        }
    }
}
