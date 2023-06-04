using System.Web.Mvc;
using System.Web.Routing;

namespace Eksamensprojekt_Final_1_Web_App
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            // Routing til alt vedrørende "User".
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

            // Routing til alt vedrørende "Home" eller chats.
            routes.MapRoute(
                name: "GetChats",
                url: "Home/GetChats",
                defaults: new { controller = "Home", action = "GetChats" }
            );

            // Routing til alt vedrørende "Message".
            routes.MapRoute(
                name: "GetMessages",
                url: "Message/GetMessages",
                defaults: new { controller = "Message", action = "GetMessages" }
            );

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
