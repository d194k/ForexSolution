using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forex.ExchangeBAL.DomainModels
{
    public class ExchangeRatesDomainModel
    {
        public bool Success { get; set; }
        public int Timestamp { get; set; }
        public bool Historical { get; set; } = false;
        public string Base { get; set; }
        public DateTime Date { get; set; }
        //public dynamic Rates { get; set; }
        public JObject Rates { get; set; }
    }
}
