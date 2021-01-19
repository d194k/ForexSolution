using Forex.ExchangeBAL.DomainModels;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forex.ExchangeBAL.Services.FixerIntegration
{
    public interface IFixerService
    {
        JObject GetAllLatestRates();
        bool CheckCurrencyCodeExists(string currencyCode);
        float CurrencyConversion(string firstCurrencyCode, string secondCurrencyCode, float amount, DateTime? date = null);
        ExchangeRatesDomainModel GetLatestExchangeRateDomainModel();
        CurrencyConversionDomainModel CurrencyConversion(CurrencyConversionDomainModel model);
    }
}
