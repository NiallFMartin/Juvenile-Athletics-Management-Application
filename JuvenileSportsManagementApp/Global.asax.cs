//Class automatically generated when project was created.
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using JuvenileSportsManagementApp.App_Start;

namespace JuvenileSportsManagementApp
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            Database.SetInitializer<JuvenileSportsManagementApp.DataAccess.SportsAppContext>(null);
            AutoMapperConfig.RegisterMappings();
        }
    }
}
