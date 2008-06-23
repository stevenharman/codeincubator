using System.Web.Mvc;
using MbUnit.Framework;
using MvcDemoApp_Preview3.Controllers;

namespace MvcDemoApp_Tests.Controllers
{
    [TestFixture]
    public class When_the_index_view_is_called_on_the_home_controller : Specification
    {
        private HomeController _controller;
        private ViewResult _result;
        private ViewDataDictionary _viewData;

        public override void before_each()
        {
            _controller = new HomeController();
            _result = _controller.Index() as ViewResult;
            _viewData = _result.ViewData;
        }

        [Test]
        public void then_verify_index_title()
        {
            _viewData["Title"].ShouldBeTheSameAs("Home Page");
        }

        [Test]
        public void then_verify_index_message()
        {
            _viewData["Message"].ShouldBeTheSameAs("Welcome to ASP.NET MVC!");
        }
    }

    [TestFixture]
    public class When_the_about_view_is_called_on_the_home_controller : Specification
    {
        private HomeController _controller;
        private ViewResult _result;
        private ViewDataDictionary _viewData;

        public override void before_each()
        {
            _controller = new HomeController();
            _result = _controller.About() as ViewResult;
            _viewData = _result.ViewData;
        }

        [Test]
        public void then_verify_about_title()
        {
            _viewData["Title"].ShouldBeTheSameAs("About Page");
        }
    }
}
