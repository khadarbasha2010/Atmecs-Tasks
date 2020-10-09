using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using API.BusinessLogic.Contract;
using API.CommonModules;
using API.Models.Request;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        private IContactsContract _contacts;
        private IMemoryCache _cache;
        public ContactsController(IContactsContract contacts, IMemoryCache cache)
        {
            _contacts = contacts;
            _cache = cache;
        }        
        [HttpGet]
        public string Get()
        {
            return new string("API Started....!");
        }
       
        [HttpPost("AddContacts")]
        public IActionResult AddContacts(RequestTblContacts req)
        {
            try
            {
                if (_contacts.AddContacts(req))
                {
                    return Content(Responsehelper.GetJsonResponse(HttpStatusCode.Created, "Created", null));
                }
                else
                {
                    return Content(Responsehelper.GetJsonResponse(HttpStatusCode.PreconditionFailed, "Failed", null));
                }
            }
            catch (Exception ex)
            {
                return Content(Responsehelper.GetJsonResponse(HttpStatusCode.PreconditionFailed, "Exception at the time of saving the data, Exception: " + ex.Message, null));
            }

        }
      
        [HttpPost("UpdateContacts")]
        public IActionResult UpdateContact(RequestTblContacts req)
        {
            try
            {
                if (_contacts.EditContacts(req))
                {
                    return Content(Responsehelper.GetJsonResponse(HttpStatusCode.OK, "Updated", null));
                }
                else
                {
                    return Content(Responsehelper.GetJsonResponse(HttpStatusCode.PreconditionFailed, "Failed", null));
                }
            }
            catch (Exception ex)
            {

                return Content(Responsehelper.GetJsonResponse(HttpStatusCode.PreconditionFailed, "Exception at the time of saving the data, Exception: " + ex.Message, null));
            }

        }
      
        [HttpDelete("DeleteContacts/{id}")]
        public IActionResult DeleteContact(int id)
        {
            try
            {
                if (_contacts.DeleteContacts(id))
                {
                    return Content(Responsehelper.GetJsonResponse(HttpStatusCode.OK, "Deleted", null));
                }
                else
                {
                    return Content(Responsehelper.GetJsonResponse(HttpStatusCode.PreconditionFailed, "Failed", null));
                }
            }
            catch (Exception ex)
            {

                return Content(Responsehelper.GetJsonResponse(HttpStatusCode.PreconditionFailed, "Exception at the time of deleting the data, Exception: " + ex.Message, null));
            }
        }
        [HttpGet("ListContacts")]
        public IActionResult ListContacts()
        {
            try
            {
               return Content(Responsehelper.GetJsonResponse(HttpStatusCode.OK, "Success", _contacts.ContactsList(string.Empty)));
                
            }
            catch (Exception ex)
            {

                return Content(Responsehelper.GetJsonResponse(HttpStatusCode.PreconditionFailed, "Exception at the time of retriving the data, Exception: " + ex.Message, null));
            }

        }
        [HttpGet("SearchedContacts/{SearchStr}")]
        public IActionResult SearchedContacts(string SearchStr)
        {
            try
            {               
                    return Content(Responsehelper.GetJsonResponse(HttpStatusCode.OK, "Success", _contacts.ContactsList(SearchStr)));
              
            }
            catch (Exception ex)
            {

                return Content(Responsehelper.GetJsonResponse(HttpStatusCode.PreconditionFailed, "Exception at the time of retriving the data, Exception: " + ex.Message, null));
            }

        }
    }
}
