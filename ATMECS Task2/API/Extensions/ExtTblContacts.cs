using API.Models.DataModel;
using API.Models.Request;
using API.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Extensions
{
    public static class ExtTblContacts
    {
        public static TblContacts ToDataTransfer(this RequestTblContacts reqTblContact)
        {
            return new TblContacts()
            {
                FirstName = reqTblContact.FirstName,
                LastName = reqTblContact.LastName,
                DateOfBirth = reqTblContact.DateOfBirth,
                ListOfEmails = reqTblContact.ListOfEmails,
                Phonenumbers = reqTblContact.Phonenumbers
            };
        }
        public static ResponseTblContatcs ToEntity(this TblContacts resTblContacts)
        {
            return new ResponseTblContatcs()
            {
                FirstName = resTblContacts.FirstName,
                LastName = resTblContacts.LastName,
                DateOfBirth = resTblContacts.DateOfBirth,
                ListOfEmails = resTblContacts.ListOfEmails,
                Phonenumbers = resTblContacts.Phonenumbers
            };
        }
    }
}
