using System;
using System.Collections.Generic;
using System.Text;

namespace FrontEnd.Business
{
     public class Contacts
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string ListOfEmails { get; set; }
        public string Phonenumbers { get; set; }
    }

    public class ContactsModel
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }
        public List<Contacts> Data { get; set; }
    }
}
