using System.Web.Mvc;
using System.Web.Routing;

namespace Eksamensprojekt_Final_1_Web_App
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            // User routes
            routes.MapRoute(
                name: "GetUsers",
                url: "User/GetUsers",
                defaults: new { controller = "User", action = "GetUsers" }
            );

            routes.MapRoute(
                name: "GetUser",
                url: "User/GetUser/{id}",
                defaults: new { controller = "User", action = "GetUser", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "CreateUser",
                url: "User/CreateUser",
                defaults: new { controller = "User", action = "CreateUser" }
            );

            routes.MapRoute(
                name: "DeleteUser",
                url: "User/DeleteUser/{id}",
                defaults: new { controller = "User", action = "DeleteUser", id = UrlParameter.Optional }
            );

            // Home routes
            routes.MapRoute(
                name: "GetChats",
                url: "Home/GetChats",
                defaults: new { controller = "Home", action = "GetChats" }
            );

            // Message routes
            routes.MapRoute(
                name: "GetMessages",
                url: "Message/GetMessages",
                defaults: new { controller = "Message", action = "GetMessages" }
            );

            // Custom route for _messagesListView
            routes.MapRoute(
                name: "MessagesListView",
                url: "Message/_messagesListView/{id}/{id2}",
                defaults: new { controller = "Message", action = "_messagesListView", id = UrlParameter.Optional, id2 = UrlParameter.Optional }
            );

            // Default route
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "GetChats", id = UrlParameter.Optional }
            );
        }
    }
}
