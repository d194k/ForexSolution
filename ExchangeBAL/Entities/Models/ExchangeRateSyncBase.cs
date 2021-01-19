using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forex.ExchangeBAL.Entities.Models
{
    [Table("ExchangeRateSyncBase")]
    public class ExchangeRateSyncBase: DBAudit
    {
        public int Id { get; set; }
        public string BaseCurrency { get; set; }
        public DateTime SyncDate { get; set; }
        public int Timestamp { get; set; }
    }
}
