using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Net.Http.Json;
using Newtonsoft.Json;
using System.Windows;

namespace FrontEnd.Business
{
    class APIConsumption
    {
       
        private HttpClient client { get; set; }
        private ContactsModel contactsModelobj { get; set; }
        public APIConsumption()
        {
           // Initialization Api
            client = new HttpClient();
            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.BaseAddress = new Uri(string.Format("https://localhost:44325/api/Contacts/"));
        }     
        public async Task<ContactsModel> GetApiCall(string pathUrl)
        {
            try
            {
                // Posting.  
                
                    Uri myUri = new Uri(client.BaseAddress, pathUrl);
                    using (HttpResponseMessage response = await client.GetAsync(myUri))
                    {

                        if (response.IsSuccessStatusCode)
                        {                        
                        var responseString = await response.Content.ReadAsStringAsync();
                        contactsModelobj = JsonConvert.DeserializeObject<ContactsModel>(responseString);
                        }
                        else
                        {
                        contactsModelobj = null;
                        }
                       
                    }
                
                
            }
            catch (Exception ex)
            {
                contactsModelobj = null;
            }
            return contactsModelobj;

        }
        public async Task<ContactsModel> postAPICall(string pathUrl, Contacts jsonBodyObj)
        {
            try
            {
                // Posting.  
               
                    Uri myUri = new Uri(client.BaseAddress, pathUrl);
                    HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, myUri);
                    var json = JsonConvert.SerializeObject(jsonBodyObj);
                    var data = new StringContent(json, Encoding.UTF8, "application/json");
                    using (HttpResponseMessage response = await client.PostAsync(myUri, data))
                    {

                        if (response.IsSuccessStatusCode)
                        {
                            
                            var responseString = await response.Content.ReadAsStringAsync();
                            contactsModelobj= JsonConvert.DeserializeObject<ContactsModel>(responseString);
                            
                        }
                        else
                        {
                        contactsModelobj=null;
                        }
                    }
                return contactsModelobj;

            }
            catch (Exception ex)
            {
                return null;
            }

            
        }
        public async Task<ContactsModel> DeleteApiCall(string pathUrl)
        {
            try
            {
                // Deleting.  

                Uri myUri = new Uri(client.BaseAddress, pathUrl);
                using (HttpResponseMessage response = await client.DeleteAsync(myUri))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        var responseString = await response.Content.ReadAsStringAsync();
                        contactsModelobj = JsonConvert.DeserializeObject<ContactsModel>(responseString);
                    }
                    else
                    {
                        contactsModelobj = null;
                    }

                }


            }
            catch (Exception ex)
            {
                contactsModelobj = null;
            }
            return contactsModelobj;

        }
    }
}
