using Forex.ExchangeBAL.DomainModels;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Forex.ExchangeBAL.Services.FixerIntegration
{
    public class FixerService: IFixerService
    {
        private readonly string _fixerApiBaseUrl;
        private readonly string _fixerApiKey;
        private readonly JObject _allRates;

        public FixerService()
        {
            _fixerApiBaseUrl = ConfigurationManager.AppSettings.Get("FixerApiBaseUrl");
            _fixerApiKey = ConfigurationManager.AppSettings.Get("FixerApiKey");
            _allRates = GetAllLatestRates();
        }

        #region Public Methods
        public JObject GetAllLatestRates()
        {
            return GetExchangeRates();
        }

        public bool CheckCurrencyCodeExists(string currencyCode)
        {
            if (currencyCode != null && _allRates.ContainsKey(currencyCode.ToUpper()))
            {
                return true;
            }
            return false;
        }

        public float CurrencyConversion(string firstCurrencyCode, string secondCurrencyCode, float amount, DateTime? date)
        {
            try
            {
                if (!CheckCurrencyCodeExists(firstCurrencyCode) || !CheckCurrencyCodeExists(secondCurrencyCode) || amount < 0)
                {
                    throw new Exception("Invalid request data");
                }
                if (amount == 0F)
                {
                    return 0F;
                }
                string[] currencyCodes = new string[] { firstCurrencyCode.ToUpper(), secondCurrencyCode.ToUpper() };
                var exchangeRates = GetExchangeRates(currencyCodes, date);
                if (exchangeRates != null && exchangeRates.ContainsKey(firstCurrencyCode) && exchangeRates.ContainsKey(secondCurrencyCode))
                {
                    var firstCurrencyRate = (float)exchangeRates[firstCurrencyCode];
                    var secondCurrencyRate = (float)exchangeRates[secondCurrencyCode];

                    return (amount / firstCurrencyRate) * secondCurrencyRate;
                }
                return default(float);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public ExchangeRatesDomainModel GetLatestExchangeRateDomainModel()
        {
            return GetExchangeRatesDomainModel();
        }

        public CurrencyConversionDomainModel CurrencyConversion(CurrencyConversionDomainModel model)
        {
            CurrencyConversionDomainModel result = default;
            try
            {                
                var exchangedAmount = CurrencyConversion(model.FirstCurrencyCode, model.SecondCurrencyCode, model.CurrencyAmount, model.ExchangeDate);
                result = result ?? new CurrencyConversionDomainModel();
                result.FirstCurrencyCode = model.FirstCurrencyCode.ToUpper();
                result.CurrencyAmount = model.CurrencyAmount;
                result.SecondCurrencyCode = model.SecondCurrencyCode.ToUpper();
                result.ExchangedAmount = exchangedAmount;
                result.ExchangeDate = model.ExchangeDate;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }
        #endregion


        #region Private Methods
        private ExchangeRatesDomainModel GetExchangeRatesDomainModel(string[] currencyCodes = null, DateTime? date = null)
        {
            ExchangeRatesDomainModel model = default(ExchangeRatesDomainModel);         
            var url = _fixerApiBaseUrl;
            if (date.HasValue)
            {
                url = url + $"/{date.Value.ToString("yyyy-MM-dd")}?access_key={_fixerApiKey}";
            }
            else
            {
                url = url + $"/latest?access_key={_fixerApiKey}";
            }
            if (currencyCodes != null && currencyCodes.Length > 0)
            {
                url = url + $"&symbols={string.Join(",", currencyCodes)}";
            }
            try
            {
                HttpWebRequest request = WebRequest.CreateHttp(url);
                request.Method = "GET";
                HttpWebResponse respone = (HttpWebResponse)request.GetResponse();
                using (var streamReader = new StreamReader(respone.GetResponseStream()))
                {
                    if (respone.StatusCode == HttpStatusCode.OK)
                    {
                        var responseData = streamReader.ReadToEnd();
                        model = JsonConvert.DeserializeObject<ExchangeRatesDomainModel>(responseData);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return model;
        }

        private JObject GetExchangeRates(string[] currencyCodes = null, DateTime? date = null)
        {
            try
            {
                var model = GetExchangeRatesDomainModel(currencyCodes, date);
                if (model != null)
                {
                    return model.Rates;
                }
                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
    }
}
