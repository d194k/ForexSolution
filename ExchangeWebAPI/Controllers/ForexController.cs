using Forex.ExchangeBAL.DomainModels;
using Forex.ExchangeBAL.Services.FixerIntegration;
using Forex.ExchangeBAL.Services.Forex;
using Forex.ExchangeBAL.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ExchangeWebAPI.Controllers
{
    [RoutePrefix("forex/api")]
    public class ForexController : ApiController
    {
        private readonly IFixerService _fixerService;
        private readonly IForexService _forexService;

        public ForexController(IFixerService fixerService, IForexService forexService)
        {
            _fixerService = fixerService;
            _forexService = forexService;
        }

        [Route("exchange")]
        [HttpPost]
        public APIResponseMessage CurrencyConversion([FromBody] CurrencyConversionDomainModel model)
        {
            HttpStatusCode statusCode = HttpStatusCode.OK;
            string message = string.Empty;
            dynamic result = null;
            try
            {
                result = _fixerService.CurrencyConversion(model);
            }
            catch (Exception ex)
            {
                APIHelper.GetErrorAPIResponseMessage(ref ex, ref statusCode, ref message);
            }
            return APIHelper.CreateAPIResponseMessage(statusCode, message, result);
        }

        [Route("ratehistory")]
        [HttpGet]
        public APIResponseMessage CurrencyConversion(string currency = null, string from = null, string to = null)
        {
            HttpStatusCode statusCode = HttpStatusCode.OK;
            string message = string.Empty;
            dynamic result = null;
            try
            {                
                result = _forexService.GetRateHistory(currency, from, to);                
            }
            catch (Exception ex)
            {
                APIHelper.GetErrorAPIResponseMessage(ref ex, ref statusCode, ref message);
            }
            return APIHelper.CreateAPIResponseMessage(statusCode, message, result);
        }
    }
}
