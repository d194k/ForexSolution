using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forex.ExchangeBAL.Entities.Models
{
    [Table("ExchangeRates")]
    public class ExchangeRates: DBAudit
    {
        public int Id { get; set; }
        public int SyncId { get; set; }
        public string Currency { get; set; }
        public double Rate { get; set; }
    }
}
