using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using System.Web.SessionState;
using System.Xml.Linq;
using StructureMap;
using MvcApplication.Controllers;
using MvcApplication.Models;
using StructureMap.Configuration.DSL;

namespace MvcApplication
{
    public class Global : System.Web.HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {
            ControllerBuilder.Current.SetDefaultControllerFactory(typeof(StructureMapControllerFactory));

            if (bool.Parse(ConfigurationManager.AppSettings["UseStructureMapDsl"]))
            {
                ConfigureContainer();
            }

            // Note: Change Url= to Url="[controller].mvc/[action]/[id]" to enable 
            //       automatic support on IIS6 

            RouteTable.Routes.Add(new Route
            {
                Url = "[controller]/[action]/[id]",
                Defaults = new { action = "Index", id = (string)null },
                RouteHandler = typeof(MvcRouteHandler)
            });

            RouteTable.Routes.Add(new Route
            {
                Url = "Default.aspx",
                Defaults = new { controller = "Home", action = "Index", id = (string)null },
                RouteHandler = typeof(MvcRouteHandler)
            });
        }

        private void ConfigureContainer()
        {
            StructureMapConfiguration.UseDefaultStructureMapConfigFile = false;

            StructureMapConfiguration.AddInstanceOf<IController>()
                .UsingConcreteType<BlogController>().WithName(typeof(BlogController).Name);

            StructureMapConfiguration.BuildInstancesOf<IController>().TheDefaultIs(
                Registry.Instance<IController>().UsingConcreteType<HomeController>()
                        .WithName(typeof(HomeController).Name));

            StructureMapConfiguration.BuildInstancesOf<IPostRepository>().TheDefaultIs(
                Registry.Instance<IPostRepository>().UsingConcreteType<InMemoryPostRepository>()
                        .WithName("InMemory"));
        }
    }
}