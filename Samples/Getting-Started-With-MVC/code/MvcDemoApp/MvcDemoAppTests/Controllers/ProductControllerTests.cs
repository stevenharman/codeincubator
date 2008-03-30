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
    class ProductControllerTests
    {
        [Test]
        public void ProductsSetsCorrectView()
        {
            ProductController controller = new ProductController();
            var fakeViewEngine = new FakeViewEngine();
            controller.ViewEngine = fakeViewEngine;

            MockRepository mocks = new MockRepository();

            using (mocks.Record())
            {
                mocks.SetFakeControllerContext(controller);
            }

            using (mocks.Playback())
            {
                controller.Products();
                Assert.AreEqual("Products", fakeViewEngine.ViewContext.ViewName);
            }
        }
    }
}
