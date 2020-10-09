using System;
using System.Collections.Generic;

namespace API.Models.DataModel
{
    public partial class TblContacts
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string ListOfEmails { get; set; }
        public string Phonenumbers { get; set; }
    }
}
