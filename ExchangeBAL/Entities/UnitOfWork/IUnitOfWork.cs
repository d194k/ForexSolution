using Forex.ExchangeBAL.Entities.Models;
using Forex.ExchangeBAL.Entities.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forex.ExchangeBAL.Entities.UnitOfWork
{
    public interface IUnitOfWork: IDisposable
    {
        void Commit();
        IRepository<ExchangeRateSyncBase> ExchangeRateSyncBaseRepository { get; }
        IRepository<ExchangeRates> ExchangeRatesRepository { get; }
    }
}
