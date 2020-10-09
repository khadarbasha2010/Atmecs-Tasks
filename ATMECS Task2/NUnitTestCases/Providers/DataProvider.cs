using API.Models.Request;
using NUnitTestCases.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace NUnitTestCases.Providers
{
    public static class DataProvider
    {
        public static IEnumerable<RequestTblContacts> ContactsData()
        {
            return ReadExcel.Exceldata("TestContactDataSource.xlsx");            
        }
        public static IEnumerable<RequestTblContacts> UpdateData()
        {
            return ReadExcel.Exceldata("UpdateDataSource.xlsx");
        }
    }
}
