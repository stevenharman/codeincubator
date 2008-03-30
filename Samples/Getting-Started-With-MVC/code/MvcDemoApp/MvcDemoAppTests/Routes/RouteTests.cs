using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MbUnit.Core;
using MbUnit.Framework;
using Rhino.Mocks;
using MvcDemoApp;
using MvcDemoApp.Controllers;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;


namespace MvcDemoAppTests.Routes
{
    [TestFixture]
    public class RouteTests
    {
        [Test]
        public void RouteDefaultsWork()
        {
            var app = new GlobalApplication();
            RouteCollection routes = new RouteCollection();
            GlobalApplication.RegisterRoutes(routes);
            Assert.GreaterThan(routes.Count, 0);
            
            MockRepository mocks = new MockRepository();
            HttpContextBase context;

            using (mocks.Record())
            {
                context = mocks.FakeHttpContext();
                context.Request.SetupRequestUrl("~/home");
            }

            using (mocks.Playback())
            {
                RouteData routeData = routes.GetRouteData(context);
                Assert.AreEqual("home", routeData.Values["controller"]);
                Assert.AreEqual("Index", routeData.Values["action"]);
                Assert.AreEqual(typeof(MvcRouteHandler), routeData.RouteHandler.GetType());
            }
        }
    }
}
