using Forex.ExchangeBAL.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forex.ExchangeBAL.Services.Forex
{
    public interface IForexService
    {
        bool SyncLatestExchangeRatesInDB();
        RateHistoryDomainModel GetRateHistory(string currencyCode, string from, string to);
    }
}
