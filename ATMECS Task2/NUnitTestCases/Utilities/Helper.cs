using API.Models.Request;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace NUnitTestCases.Utilities
{
    public static class Helper
    {
        public static HttpContent SetContent(RequestTblContacts objData)
        {
            var json = JsonConvert.SerializeObject(objData);
            return new StringContent(json, Encoding.UTF8, "application/json");
        }
    }
}
