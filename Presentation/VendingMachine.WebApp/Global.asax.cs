using log4net;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Unity.ServiceLocation;
using VendingMachine.Migration;
using VendingMachine.WebApp.App_Start;

namespace VendingMachine.WebApp
{
    public class MvcApplication : System.Web.HttpApplication
    {
        private readonly ILog log = LogManager.GetLogger("VendingMachine.WebApp");

        protected void Application_Start()
        {
            log4net.Config.XmlConfigurator.Configure();
            

            UnityServiceLocator serviceLocator = new UnityServiceLocator(UnityConfig.GetConfiguredContainer());
            
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            
            IMigrationRunner migrationRunner = serviceLocator.GetInstance<IMigrationRunner>();
            migrationRunner.Update();

        }
    }
}
