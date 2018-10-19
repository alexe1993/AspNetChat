using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace TestChat
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}/{*catchall}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional},
                namespaces: new[] { "TestChat.Controllers" });
        }
    }
   
    public class CustomConstraint : IRouteConstraint
    {
        string m_url;

        public CustomConstraint(string url)
        {
            m_url = url;
        }

        public bool Match(HttpContextBase httpContext, Route route, string parameterName, RouteValueDictionary values, RouteDirection routeDirection)
        {
            return httpContext.Request.Url.AbsolutePath != m_url;
        }
    }
}