using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forex.ExchangeBAL.DomainModels
{
    public class RateHistoryDomainModel
    {
        public string CurrencyCode { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public List<RateDomainModel> Records { get; set; }
    }

    public class RateDomainModel
    {
        public DateTime RecordDate { get; set; }
        public double ExchangeRate { get; set; }
    }
}
