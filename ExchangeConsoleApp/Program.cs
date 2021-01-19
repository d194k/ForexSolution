using Autofac;
using Forex.ExchangeBAL.Services.FixerIntegration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forex.ExchangeConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var container = GetIocContainer();
                IFixerService _fixerService = container.Resolve<IFixerService>();

                Console.Title = "FOREX - CURRENCY CONVERSION";

            QUESTION:
                Console.Clear();
                Console.Write("Want to get currency conversion with current(Y) or past-dated(N) rate?(Y/N): ");
                var answar1 = Console.ReadLine().Trim().ToUpper();
                DateTime? date = null;
                if (answar1 == "Y")
                {
                    goto START;
                } 
                else if(answar1 == "N")
                {
                    Console.Write("Please enter date in YYYY-MM-DD format: ");
                    var input = Console.ReadLine().Trim();
                    DateTime outDate;
                    if (DateTime.TryParse(input, out outDate))
                    {
                        date = outDate;
                    }
                    else
                    {
                        Console.Write("Invalid date entered!");
                        Console.ReadKey();
                        goto QUESTION;
                    }
                }
                else
                {                    
                    goto QUESTION;
                }

            START:
                Console.Write("Please enter first currency code: ");
                var firstCurrencyCode = Console.ReadLine().ToUpper().Trim();
                if (!_fixerService.CheckCurrencyCodeExists(firstCurrencyCode))
                {
                    Console.Write("Invalid currency code entered!");
                    Console.ReadKey();
                    goto QUESTION;
                }

                Console.Write("Please enter curency amount to exchange: ");
                var i = Console.ReadLine();
                float amount = 0F;
                if (!float.TryParse(i, out amount) && amount < 0)
                {
                    Console.Write("Invalid amount entered!");
                    Console.ReadKey();
                    goto QUESTION;
                }

                Console.Write("Please enter second currency code: ");
                var secondCurrencyCode = Console.ReadLine().ToUpper().Trim();
                if (!_fixerService.CheckCurrencyCodeExists(secondCurrencyCode))
                {
                    Console.Write("Invalid currency code entered!");
                    Console.ReadKey();
                    goto QUESTION;
                }

                var ExchangedAmount = _fixerService.CurrencyConversion(firstCurrencyCode, secondCurrencyCode, amount, date);
                Console.WriteLine($"{amount} {firstCurrencyCode} = {ExchangedAmount} {secondCurrencyCode}");

            CLOSE:
                Console.Write("Want to close application?(Y/N): ");
                var answar = Console.ReadLine().ToUpper();
                if (answar == "Y")
                {
                    Environment.Exit(0);                    
                } 
                else if (answar == "N")
                {
                    goto QUESTION;
                } 
                else
                {
                    goto CLOSE;
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

            // Return Container
            return containerBuilder.Build();
        }
    }
}
