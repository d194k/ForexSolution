using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forex.ExchangeBAL.DomainModels
{
    public class ExchangeRateSyncBaseDomainModel
    {
        public int Id { get; set; }
        public string BaseCurrency { get; set; }
        public DateTime SyncDate { get; set; }
    }
}
