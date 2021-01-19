using Forex.ExchangeBAL.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Forex.ExchangeBAL.Utilities
{
    public static class APIHelper
    {
        public static APIResponseMessage CreateAPIResponseMessage(HttpStatusCode statusCode = HttpStatusCode.BadRequest, string message = null, dynamic result = null)
        {
            return new APIResponseMessage() { StatusCode = (int)statusCode, StatusDescription = statusCode.ToString(), Message = message, Result = result };
        }

        public static void GetErrorAPIResponseMessage(ref Exception ex, ref HttpStatusCode statusCode, ref string message)
        {
            statusCode = HttpStatusCode.BadRequest;
            message = ex.Message;
        }
    }
}
