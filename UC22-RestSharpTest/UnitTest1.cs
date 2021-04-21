using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using RestSharp;
using System.Collections.Generic;
using System.Net;
using UC22_ReadContactUsingJsonServer;

namespace UC22_RestSharpTest
{
    [TestClass]
    public class UnitTest1
    {
        RestClient client;

        [TestInitialize]
        public void Setup()
        {
            client = new RestClient("http://localhost:4000");
        }

        public IRestResponse GetEmployeeList()
        {
            //arrange
            RestRequest request = new RestRequest("/Contacts", Method.GET);

            //act
            IRestResponse response = client.Execute(request);
            return response;
        }

        /// <summary>
        /// Test case to retrieve all Contacts using json server and match result by asserting
        /// </summary>
        [TestMethod]
        public void onCallingGETApi_ReturnContactList()
        {
            IRestResponse response = GetEmployeeList();
            //assert
            Assert.AreEqual(response.StatusCode, HttpStatusCode.OK);
            List<Contacts> dataResponse = JsonConvert.DeserializeObject<List<Contacts>>(response.Content);
            Assert.AreEqual(5, dataResponse.Count);
            foreach (Contacts contact in dataResponse)
            {
                System.Console.Write("First name: " + contact.first_name + " \nLast name: " + contact.last_name + " \nAddress: " + contact.address + " \nCity: " + contact.city + " \nState: "
                    + contact.state + " \nZip:" + contact.zip + " \nPhone Number:" + contact.phone_number + " \nEmail:" + contact.email);
            }
        }
    }
}
