using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using API.Models.DataModel;
using API.Models.Request;
using Newtonsoft.Json;

namespace API.CommonModules
{
    public static class Responsehelper
    {
        public static string GetJsonResponse(HttpStatusCode statusCode, string message, IEnumerable<TblContacts> data)
        {
            ResponseStatusData res = new ResponseStatusData();
            try
            {
                res.StatusCode = (int)statusCode;
                res.Message = message;
                res.Data = data;
                return JsonConvert.SerializeObject(res);

            }
            catch (Exception ex)
            {
                return "{\"StatusCode\":" + HttpStatusCode.InternalServerError + ",\"Message\":" + ex.Message + ",\"data\":[]}";
            }
        }
    }



    public class ResponseStatusData
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }
        public IEnumerable<TblContacts> Data { get; set; }
    }



}


