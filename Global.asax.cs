using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using HubSpace.Web.Models;
using HubSpace.Web.Migrations;

namespace HubSpace.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            // 1. Define a estratégia de migração automática
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<HubSpaceContext, Configuration>());

            // 2. Força o EF a checar/aplicar migrações pendentes na inicialização
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