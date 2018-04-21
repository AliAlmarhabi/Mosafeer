using System;
using System.Collections.Generic;
using System.Net.Http;
using T.D.Project.Models;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace T.D.Project.Services
{
    public class AzureService
    {
        //declaring a variables.
        private string response = string.Empty;
        private string item = string.Empty;

        //get userProfile from database.
        public  List<Customer> getUserProfile(string from, string to)
        {
            List<Customer> customer = new List<Customer>();
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    // string path = "https://mobilityservices.azurewebsites.net/";
                    //string path = "http://testmobilityservices.azurewebsites.net/api/RegisterDriver";
                    client.BaseAddress = new Uri("http://mobilityservicespro.azurewebsites.net/");
                    string response = client.GetStringAsync("api/RegisterDriver/?" + "from="+ from + "&" + "to="+ to).Result;
                      //response =  client.GetStringAsync(response).Result;
                    if (response.Length > 0)
                    {
                        customer = JsonConvert.DeserializeObject<List<Customer>>(response);
                    }
                }
            }
            catch (Exception ex)
            {
                customer.Add(new Customer() { Error = string.Format("Error Message:{0}", ex.Message) });
            }
            return customer;
        }

        //call mobilityservice APIs to add new customer to database
        public bool AddNewUser(Customer customer)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://mobilityservicespro.azurewebsites.net/");
                //convert object to json
                var obj = JsonConvert.SerializeObject(customer);
                HttpContent content = new StringContent(obj);
                 client.DefaultRequestHeaders.Accept.Clear();
                 content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                HttpResponseMessage response = client.PostAsync("api/RegisterDriver/", content).Result;
                return response.IsSuccessStatusCode;
            }
        }
    }
}
