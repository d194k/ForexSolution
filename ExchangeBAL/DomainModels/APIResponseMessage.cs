using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Forex.ExchangeBAL.DomainModels
{
    public class APIResponseMessage
    {
        public int StatusCode { get; set; }
        public string StatusDescription { get; set; }
        public string Message { get; set; }
        public dynamic Result { get; set; }
    }
}
