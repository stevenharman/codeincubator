using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MbUnit.Core;
using MbUnit.Framework;
using Rhino.Mocks;
using MvcDemoApp;
using MvcDemoApp.Controllers;
using System.Web.Mvc;

namespace MvcDemoAppTests.Controllers
{
    [TestFixture]
    public class HomeControllerTests
    {
        //[Test]
        //public void FooSetsCorrectView()
        //{
        //    HomeController controller = new HomeController();
        //    var fakeViewEngine = new FakeViewEngine();
        //    controller.ViewEngine = fakeViewEngine;

        //    MockRepository mocks = new MockRepository();

        //    using (mocks.Record())
        //    {
        //        mocks.SetFakeControllerContext(controller);
        //    }

        //    using (mocks.Playback())
        //    {
        //        controller.Foo();
        //        Assert.AreEqual("Index", fakeViewEngine.ViewContext.ViewName);
        //    }
        //}

        [Test]
        public void About()
        {
            //
            // TODO: Add test logic	here
            //
        }

        [Test]
        public void Index()
        {
            //
            // TODO: Add test logic	here
            //
        }
    }
}
