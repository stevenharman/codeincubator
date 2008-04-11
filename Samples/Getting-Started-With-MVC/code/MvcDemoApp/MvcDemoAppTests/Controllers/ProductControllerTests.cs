using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MbUnit.Core;
using MbUnit.Framework;
using Rhino.Mocks;
using MvcDemoApp;
using MvcDemoApp.Controllers;
using MvcDemoApp.Models;
using System.Web.Mvc;

namespace MvcDemoAppTests.Controllers
{
    [TestFixture]
    class ProductControllerTests
    {
        [Test]
        public void ProductsSetsCorrectView()
        {
            var mocks = new MockRepository();
            var repository = mocks.DynamicMock<IProductRepository>();
            ProductController controller;
            
            using (mocks.Record())
            {
                Expect.Call(repository.GetTenProducts()).Return(new[] { new Product() }.ToList());

                controller = new ProductController(repository);
                mocks.SetFakeControllerContext(controller);
            }

            var fakeViewEngine = new FakeViewEngine();
            controller.ViewEngine = fakeViewEngine;

            using (mocks.Playback())
            {
                controller.Products();
                Assert.AreEqual("Products", fakeViewEngine.ViewContext.ViewName);
            }
        }

        [Test]
        public void DoesViewRenderProductById()
        {
            var mocks = new MockRepository();
            IProductRepository repository;
            ProductController controller;
            var viewEngine = new FakeViewEngine();

            using (mocks.Record())
            {
                repository = mocks.CreateMock<IProductRepository>();
                SetupResult.For(repository.GetProductById(7)).Return(new Product { Name = "Bingo", ProductID = 7, Color = "Blue" });

                controller = new ProductController(repository);
                mocks.SetFakeControllerContext(controller);
                controller.ViewEngine = viewEngine;
            }

            using (mocks.Playback())
            {
                controller.Edit(7);
                Assert.AreEqual(7, ((Product)viewEngine.ViewContext.ViewData).ProductID);
            }
        }
    }
}
