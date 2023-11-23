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
    public class EmergencyContacts_Repo:Repo<EmergencyContacts>,IEmergencyContacts_Repo
    {
        private readonly ERPDb eRPDb;
        public EmergencyContacts_Repo(ERPDb db):base(db) 
        {
                eRPDb = db;
        }
    }
}
