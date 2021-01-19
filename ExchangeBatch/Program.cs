using Autofac;
using Forex.ExchangeBAL.Entities;
using Forex.ExchangeBAL.Entities.UnitOfWork;
using Forex.ExchangeBAL.Services.FixerIntegration;
using Forex.ExchangeBAL.Services.Forex;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExchangeBatch
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.Title = "Daily Exchange Rate Processing - Batch";

                var container = GetIocContainer();
                IForexService _forexService = container.Resolve<IForexService>();

                Console.WriteLine("Starting batch");
                var data = _forexService.SyncLatestExchangeRatesInDB();
                Console.WriteLine("Processing ended");

                if (data)
                {
                    Console.WriteLine("Sync successed");
                }
                else
                {
                    Console.WriteLine("Nothing Synced");
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("Fatal error: " + ex.Message);
                Console.ReadKey();
            }
        }

        public static IContainer GetIocContainer()
        {
            var containerBuilder = new ContainerBuilder();

            // Register services in container
            containerBuilder.RegisterType<FixerService>().As<IFixerService>();            
            containerBuilder.RegisterType<ForexDbContext>().AsSelf();
            containerBuilder.RegisterType<UnitOfWork>().As<IUnitOfWork>();
            containerBuilder.RegisterType<ForexService>().As<IForexService>();

            // Return Container
            return containerBuilder.Build();
        }
    }
}
