using API.BusinessLogic.Contract;
using API.Extensions;
using API.Models.DataModel;
using API.Models.Request;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.BusinessLogic
{
    public class ContactsBusiness: IContactsContract
    {
        public ATMECSDBContext _dbContext { get; set; }
        private IMemoryCache _cache;
        public ContactsBusiness()
        {

        }
        public ContactsBusiness(ATMECSDBContext dbContext, IMemoryCache cache)
        {
            _dbContext = dbContext;
            _cache = cache;
        }
               
        public Boolean AddContacts(RequestTblContacts _req)
        {
            _dbContext.TblContacts.Add(ExtTblContacts.ToDataTransfer(_req));
            int rowcount = _dbContext.SaveChanges();
            return rowcount==1;
        }
        public Boolean EditContacts(RequestTblContacts _req)
        {
            try
            {
                var CurrentObj = _dbContext.TblContacts.Find(_req.Id);
                CurrentObj.FirstName = _req.FirstName;
                CurrentObj.LastName = _req.LastName;
                CurrentObj.DateOfBirth = _req.DateOfBirth;
                CurrentObj.Phonenumbers = _req.Phonenumbers;
                CurrentObj.ListOfEmails = _req.ListOfEmails;
                int rowcount = _dbContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
                    
            
        }
        public Boolean DeleteContacts(int id)
        {
            var CurrentObj = _dbContext.TblContacts.Remove(_dbContext.TblContacts.Find(id));
            _dbContext.SaveChanges();
            return true;
        }
        public IEnumerable<TblContacts> ContactsList(string searchStr="")
        {
            if (!string.IsNullOrEmpty( searchStr))
            {
                searchStr = searchStr.ToLower();
                return _dbContext.TblContacts.Where(e => e.FirstName.ToLower().Contains(searchStr) || e.LastName.ToLower().Contains(searchStr)).ToList();

            }
            else
            {
                return _dbContext.TblContacts.ToList().OrderByDescending(e=>e.Id).Take(100);
            }          
        }
       
    }
}
