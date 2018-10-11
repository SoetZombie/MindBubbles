using LightInject;
using MindBubbles3.Models;
using MindBubbles3.Service.Implementations;
using MindBubbles3.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace MindBubbles3
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            var container = new ServiceContainer();
            container.RegisterControllers();
            //register other services
            container.Register<IBubbleService, BubbleService>(new PerScopeLifetime());

            container.EnableMvc();
         //   Database.SetInitializer(new DropCreateDatabaseAlways<ApplicationDbContext>());
        }
    }
}
