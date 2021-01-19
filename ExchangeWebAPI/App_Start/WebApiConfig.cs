using Autofac;
using Autofac.Integration.WebApi;
using Forex.ExchangeBAL.Entities;
using Forex.ExchangeBAL.Entities.UnitOfWork;
using Forex.ExchangeBAL.Services.FixerIntegration;
using Forex.ExchangeBAL.Services.Forex;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web.Http;
using System.Web.Http.Cors;

namespace ExchangeWebAPI
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            var cors = new EnableCorsAttribute("*", "*", "*");
            config.EnableCors(cors);

            //DI
            var global = GlobalConfiguration.Configuration;

            var containerBuilder = new ContainerBuilder();
            containerBuilder.RegisterApiControllers(Assembly.GetExecutingAssembly());
            containerBuilder.RegisterType<FixerService>().As<IFixerService>();
            containerBuilder.RegisterType<ForexService>().As<IForexService>();
            containerBuilder.RegisterType<ForexDbContext>().AsSelf();
            containerBuilder.RegisterType<UnitOfWork>().As<IUnitOfWork>();
            var container = containerBuilder.Build();

            global.DependencyResolver = new AutofacWebApiDependencyResolver(container);

            // Web API routes
            config.MapHttpAttributeRoutes();

            //config.Routes.MapHttpRoute(
            //    name: "DefaultApi",
            //    routeTemplate: "api/{controller}/{id}",
            //    defaults: new { id = RouteParameter.Optional }
            //);
        }
    }
}
