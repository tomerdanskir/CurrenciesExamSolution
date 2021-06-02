using CurrenciesIntreviewTomer.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CurrenciesIntreviewTomer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExchangerateController : ControllerBase
    {
        private ICallingExternalApi _externalApi;

        public ExchangerateController(ICallingExternalApi externalApi)
        {
            _externalApi = externalApi;
        }

        [HttpPost]
        [ActionName("exchangerate")]
        public async Task<ActionResult<double>> Exchangerate([FromBody]JObject data)
        {
            double totalAmount = 0;
            JObject jsonData = await _externalApi.GetExternalAPIData();

            var convertingData = data["ToConvert"];

            foreach (var element in convertingData)
            {
                var dstCoin = element["Currency"].ToString();
                string apiJsonKey = "USD" + dstCoin.ToUpper();
                var amountToConvert = double.Parse(element["Amount"].ToString());
                var rateOfCoin = double.Parse(jsonData["quotes"][apiJsonKey].ToString());

                totalAmount += rateOfCoin * amountToConvert;
            }
            return totalAmount;
        }
    }
}
