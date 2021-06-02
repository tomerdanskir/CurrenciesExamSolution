using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace CurrenciesIntreviewTomer.Services
{
    public class CallingExternalApi : ICallingExternalApi
    {

        private string apiAdress = "http://api.currencylayer.com/live?access_key=f10dd14936c5e38e03b0ea9b221b0f91";

        public async Task<JObject> GetExternalAPIData()
        {
            var client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync(apiAdress);
            try
            {
                response.EnsureSuccessStatusCode();
            }
            catch 
            {
                return new JObject("Error on requesting External API");
            }
           
            var result = await response.Content.ReadAsStringAsync();
            JObject jsonData = JObject.Parse(result);
            return jsonData;
        }
    }
}
