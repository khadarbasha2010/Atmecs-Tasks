using System;
using System.Collections.Generic;
using System.Text;

namespace NUnitTestCases.Models
{
    public class ContactsTestModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string ListOfEmails { get; set; }
        public string Phonenumbers { get; set; }
    }
}
