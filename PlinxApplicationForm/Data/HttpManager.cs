using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using System.Net.Http;
using PlinxApplicationForm.Models;
using PlinxApplicationForm.Models.Request;
using Newtonsoft.Json;
using System.Text;

namespace PlinxApplicationForm.Data
{
    public class HttpManager : IHttpManager
    {
        private static readonly HttpClient client = new HttpClient();

        public  HttpResponseMessage Post(Customer applicationFormModel)
        {
            const string API_URL = "http://localhost:5200/api/v1/Customer";
     

            var content = new StringContent(JsonConvert.SerializeObject(applicationFormModel), Encoding.UTF8, "application/json");
            var result = client.PostAsync(API_URL, content).Result;

           // var response =  await client.PostAsync(API_URL, values);

            return result;
        }

    }
}
