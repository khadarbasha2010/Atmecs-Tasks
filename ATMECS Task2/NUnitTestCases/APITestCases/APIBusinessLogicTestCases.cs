using API;
using API.Models.DataModel;
using API.Models.Request;
using FluentAssertions;
using FrontEnd.Business;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Newtonsoft.Json;
using NUnit.Framework;
using NUnitTestCases.Providers;
using NUnitTestCases.Utilities;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace NUnitTestCases.APITestCases
{
    class APIBusinessLogicTestCases
    {
        private HttpClient _clients;
        private List<Contacts> cmodel;
        [SetUp]
        public void Setup()
        {
            var appfactory = new WebApplicationFactory<Startup>()
                .WithWebHostBuilder(builder =>
                {
                    builder.ConfigureServices(services =>
                    {
                        services.RemoveAll(typeof(ATMECSDBContext));
                        services.AddDbContext<ATMECSDBContext>(options =>
                        {
                            options.UseInMemoryDatabase("TestingDb");
                        });
                    });
                });
            _clients = appfactory.CreateClient();
            cmodel = new List<Contacts>();
        }

        [Test, Order(1)]
        public async Task TestApiIsRunningProperly()
        {
            // Basic Get Call
            var response = await _clients.GetAsync("/api/Contacts/");
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            (await response.Content.ReadAsStringAsync()).Should().Be("API Started....!");

        }
        [Test, Order(2), TestCaseSource(typeof(DataProvider), "ContactsData")]
        public async Task TestAddContacts(RequestTblContacts obj)
        {            
            var response = await _clients.PostAsync("/api/Contacts/AddContacts", Helper.SetContent(obj));
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            var responseString = await response.Content.ReadAsStringAsync();
            JsonConvert.DeserializeObject<ContactsModel>(responseString).Message.Should().Be("Created");

        }
        [Test, Order(3)]
        public async Task GetContacts()
        {
            var response = await _clients.GetAsync("/api/Contacts/ListContacts");
           
            var responseString = await response.Content.ReadAsStringAsync();
            cmodel= JsonConvert.DeserializeObject<ContactsModel>(responseString).Data;
            response.StatusCode.Should().Be(HttpStatusCode.OK);

        }
        [Test, Order(4), TestCaseSource(typeof(DataProvider), "UpdateData")]
        public async Task UpdateContactContacts(RequestTblContacts obj)
        {
            if(cmodel.Count!=0)
            {
            obj.Id = cmodel[0].Id;
            var response = await _clients.PostAsync("/api/Contacts/UpdateContacts", Helper.SetContent(obj));
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            var responseString = await response.Content.ReadAsStringAsync();
            JsonConvert.DeserializeObject<ContactsModel>(responseString).Message.Should().Be("Updated");
            }

        }
        // SearchedContacts/{SearchStr}
        [Test, Order(5)]
        public async Task SearchContacts()
        {
            var response = await _clients.GetAsync("/api/Contacts/SearchedContacts/KB");

            var responseString = await response.Content.ReadAsStringAsync();
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }
        [Test, Order(6)]
        public async Task DeleteContacts()
        {
            if (cmodel.Count != 0)
            {
                var response = await _clients.GetAsync("/api/Contacts/DeleteContacts/" + cmodel[cmodel.Count-1].Id);

                var responseString = await response.Content.ReadAsStringAsync();
                response.StatusCode.Should().Be(HttpStatusCode.OK);
            }

        }
    }



}
