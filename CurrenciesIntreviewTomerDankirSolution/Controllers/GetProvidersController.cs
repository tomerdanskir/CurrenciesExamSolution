using CurrenciesIntreviewTomer.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace CurrenciesIntreviewTomer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GetProvidersController : ControllerBase
    {
        private ICallingExternalApi _externalApi;
        public GetProvidersController(ICallingExternalApi externalApi)
        {
            _externalApi = externalApi;
        }
        
        [HttpGet]
        [ActionName("getproviders")]
        public async Task<ActionResult<string[]>> GetProviders()
        {
            string[] allProviders;
            List<string> allProvidersList = new List<string>();

            var jsonData = await _externalApi.GetExternalAPIData();
            
            var allCurrencies = jsonData["quotes"];

            foreach (JProperty attributeProperty in allCurrencies)
            {
                var attribute = attributeProperty.Name.Substring(3);
                allProvidersList.Add(attribute.ToString());
            }

            allProviders = allProvidersList.ToArray<string>();
            return allProviders;
        }
    }

   

}
