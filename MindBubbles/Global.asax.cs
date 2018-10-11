using LightInject;
using MindBubbles.Service.Implementations;
using MindBubbles.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace MindBubbles
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
        }
    }
}
