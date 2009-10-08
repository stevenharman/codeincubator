using System.Web.Routing;
using MvcContrib.TestHelper;
using NUnit.Framework;
using StarDestroyer.Controllers;

namespace StarDestroyer.Tests.Routes
{
    public class When_accessing_urls_for_the_star_destroyer_mvc_app : Specification
    {
        protected override void Before_each()
        {
            MvcApplication.RegisterRoutes(RouteTable.Routes);
            base.Before_each();
        }

        protected override void After_each()
        {
            RouteTable.Routes.Clear();
            base.After_each();
        }

        [Test]
        public void Should_map_blank_url_to_home()
        {
            "~/".Route().ShouldMapTo<HomeController>(c => c.Index());
        }

        [Test]
        public void Product_searches_should_map_to_the_product_search_action()
        {
                "~/Product/Something".Route().ShouldMapTo<ProductController>(c => c.Search("Something"));
        }
    }
}