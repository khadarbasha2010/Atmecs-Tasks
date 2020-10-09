using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace FrontEnd.ViewModels
{
    public static class ViewModelClass
    {
        public static string DataValidation(string fname, string lname)
        {
            string msg = string.Empty;
            if (fname == "")
            {
                msg += "Please Enter FirstName \r\n";
            }
            if (lname == "")
            {
                msg += "Please enter Last Name";
            }
            return msg;
        }
    }
}
