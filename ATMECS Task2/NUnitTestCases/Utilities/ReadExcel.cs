using API.Models.Request;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace NUnitTestCases.Utilities
{
    public static class ReadExcel
    {
        public static IEnumerable<RequestTblContacts> ReadFromExcel(string excelFileName, string excelsheetTabName)
        {
            return null;
        }
        public static byte[] ReadFully(Stream input)
        {
            byte[] buffer = new byte[16 * 1024];
            using (MemoryStream ms = new MemoryStream())
            {
                int read;
                while ((read = input.Read(buffer, 0, buffer.Length)) > 0)
                {
                    ms.Write(buffer, 0, read);
                }
                return ms.ToArray();
            }
        }

        public static IEnumerable<RequestTblContacts> Exceldata(string fileName)
        {
            List<RequestTblContacts> contactsdatafromExcel = new List<RequestTblContacts>();
            if (string.IsNullOrEmpty(fileName)) fileName = "TestContactDataSource.xlsx";
           
            string direcotry = Directory.GetCurrentDirectory();
            string pth = Directory.GetParent(direcotry).Parent.Parent.FullName;
            string fileWithLocation = Path.Combine(Path.Combine(pth, "Assets"), fileName);
            FileInfo fileInfo = new FileInfo(fileWithLocation);
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            ExcelPackage package = new ExcelPackage(fileInfo);           
            ExcelWorksheet worksheet = package.Workbook.Worksheets.FirstOrDefault();

            int rows = worksheet.Dimension.Rows;
            int columns = worksheet.Dimension.Columns;
            List<string> columnNames = new List<string>();
            
            for (int i = 1; i < columns; i++)
            {
                columnNames.Add(worksheet.Cells[1,i].Value.ToString().Trim());
            }
            for (int i = 2; i <= rows; i++)
            {
                RequestTblContacts obj = new RequestTblContacts()
                {
                    FirstName= worksheet.Cells[i,1].Value.ToString().Trim(),
                    LastName = worksheet.Cells[i,2].Value.ToString().Trim(),
                    DateOfBirth = (DateTime)worksheet.Cells[i,3].Value,
                    ListOfEmails = worksheet.Cells[i,4].Value.ToString().Trim(),
                    Phonenumbers = worksheet.Cells[i,5].Value.ToString().Trim(),
                };
                contactsdatafromExcel.Add(obj);
            }
            return contactsdatafromExcel;
        }
    }
}

