using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CurrenciesIntreviewTomer.Services
{
    public interface ICallingExternalApi
    {
        public Task<JObject> GetExternalAPIData();
    }
}
