using System.Data.SqlClient;
using SignalRWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Http;

namespace SignalRWebApp
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected String SqlConnectionString { get; set; }
 
        protected void Application_Start()
        {
            using (var context = new EntityBase())
                SqlConnectionString = context.Database.Connection.ConnectionString;
        
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            GlobalConfiguration.Configure(WebApiConfig.Register);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            
            if (!String.IsNullOrEmpty(SqlConnectionString))
                SqlDependency.Start(SqlConnectionString);
        }

        protected void Application_End()
        {
            if (!String.IsNullOrEmpty(SqlConnectionString))
                SqlDependency.Start(SqlConnectionString);
        }
    }
}