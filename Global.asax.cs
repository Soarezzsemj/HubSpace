using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Data.Entity;
using HubSpace.Web.Models;
namespace HubSpace.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            // 1. Define a estratégia de criação
            Database.SetInitializer(new CreateDatabaseIfNotExists<HubSpaceContext>());

            // 2. Linha temporária: Força o EF a disparar o banco agora na inicialização
            using (var ctx = new HubSpaceContext())
            {
                ctx.Database.Initialize(force: true);
            }

            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}