using System.Linq;
using System.Web.Http;
using Unity.ServiceLocation;
using VendingMachine.WebApp.App_Start;

namespace VendingMachine.WebApp
{
    public static class WebApiConfig
    {
        // Web API configuration and services
        public static void Register(HttpConfiguration config)
        {
            //Unity configuration for Web API controllers
            var container = UnityConfig.GetConfiguredContainer();
            config.DependencyResolver = new UnityResolver(container);

            UnityServiceLocator serviceLocator = new UnityServiceLocator(container);
            
            // Web API routes
            config.MapHttpAttributeRoutes();



            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{action}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
            
            var appXmlType = config.Formatters.XmlFormatter.SupportedMediaTypes.FirstOrDefault(t => t.MediaType == "application/xml");
            config.Formatters.XmlFormatter.SupportedMediaTypes.Remove(appXmlType);

        }
    }
}