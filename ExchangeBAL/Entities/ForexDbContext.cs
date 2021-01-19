using Forex.ExchangeBAL.Entities.Models;
using System.Data.Entity;

namespace Forex.ExchangeBAL.Entities
{
    public class ForexDbContext: DbContext
    {
        public ForexDbContext(): base("name=ForexDBConnectionString")
        {
            Database.CommandTimeout = 300;
            Database.SetInitializer<ForexDbContext>(null);
        }
        
        public virtual DbSet<ExchangeRateSyncBase> ExchangeRateSyncBase { get; set; }
        public virtual DbSet<ExchangeRates> ExchangeRates { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
