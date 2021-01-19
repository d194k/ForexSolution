using Forex.ExchangeBAL.Entities.Models;
using Forex.ExchangeBAL.Entities.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forex.ExchangeBAL.Entities.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ForexDbContext _context;
        private IRepository<ExchangeRateSyncBase> _exchangeRateSyncBaseRepository = null;
        private IRepository<ExchangeRates> _exchangeRatesRepository = null;

        public UnitOfWork(ForexDbContext context)
        {
            _context = context;
        }

        public IRepository<ExchangeRateSyncBase> ExchangeRateSyncBaseRepository 
        { 
            get 
            {
                if(_exchangeRateSyncBaseRepository == null)
                {
                    _exchangeRateSyncBaseRepository = new Repository<ExchangeRateSyncBase>(_context);
                }
                return _exchangeRateSyncBaseRepository;
            } 
        }

        public IRepository<ExchangeRates> ExchangeRatesRepository 
        {
            get 
            {
                if (_exchangeRatesRepository == null)
                {
                    _exchangeRatesRepository = new Repository<ExchangeRates>(_context);
                }
                return _exchangeRatesRepository;
            }
        }
        public void Commit()
        {
            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    _context.SaveChanges();
                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                }
            }            
        }       
        
        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
