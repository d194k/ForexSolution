using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forex.ExchangeBAL.DomainModels
{
    public class CurrencyConversionDomainModel
    {
        public string FirstCurrencyCode { get; set; }
        public string SecondCurrencyCode { get; set; }
        public float CurrencyAmount { get; set; }
        public DateTime? ExchangeDate { get; set; }
        public float ExchangedAmount { get; set; }
    }
}
