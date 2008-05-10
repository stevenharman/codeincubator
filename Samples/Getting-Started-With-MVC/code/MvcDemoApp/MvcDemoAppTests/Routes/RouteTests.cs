using MbUnit.Framework;
using Rhino.Mocks;
using MvcDemoApp;
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
            var routes = new RouteCollection();
            GlobalApplication.RegisterRoutes(routes);
            Assert.GreaterThan(routes.Count, 0);
            
            var mocks = new MockRepository();
            HttpContextBase context;

            using (mocks.Record())
            {
                context = mocks.FakeHttpContext();
                context.Request.SetupRequestUrl("~/home");
            }

            using (mocks.Playback())
            {
                var routeData = routes.GetRouteData(context);
                Assert.AreEqual("home", routeData.Values["controller"]);
                Assert.AreEqual("Index", routeData.Values["action"]);
                Assert.AreEqual(typeof(MvcRouteHandler), routeData.RouteHandler.GetType());
            }
        }
    }
}
