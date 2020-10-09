using API.Models.DataModel;
using API.Models.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.BusinessLogic.Contract
{
    public interface IContactsContract
    {
        public Boolean AddContacts(RequestTblContacts req);
        public Boolean EditContacts(RequestTblContacts req);
        public Boolean DeleteContacts(int id);       
        public IEnumerable<TblContacts> ContactsList(string searchStr = "");
    }
}
