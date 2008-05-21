using System.Collections.Generic;
using System.Linq;
using MbUnit.Framework;
using MvcApplication.Models;
using Rhino.Mocks;

namespace MvcApplicationTest.Models
{
    [TestFixture]
    public class ProductRepositoryTests
    {
        [Test]
        public void TestStubInterfaceMethod()
        {
            var mocks = new MockRepository();
            var products = mocks.Stub<IProductRepository>();

            using (mocks.Record())
            {
                SetupResult.For(products.Select()).Return(_fakeProducts);
            }

            var results = products.Select();
            Assert.AreEqual(3, results.Count());
        }

        [Test]
        public void TestStubMultipleReturn()
        {
            var mocks = new MockRepository();
            var products = mocks.Stub<IProductRepository>();

            using (mocks.Record())
            {
                SetupResult
                    .For(products.Get(2))
                    .Return(new Product {Name = "Beer", Price = 12.99m});


                SetupResult
                    .For(products.Get(12))
                    .Return(new Product {Name = "Steak", Price = 8.02m});
            }

            // Test
            IProduct product1 = products.Get(2);
            Assert.AreEqual("Beer", product1.Name);

            IProduct product2 = products.Get(12);
            Assert.AreEqual("Steak", product2.Name);

            IProduct product3 = products.Get(13);
            Assert.IsNull(product3);
        }

        [Test]
        public void TestStubIgnoreArguments()
        {
            var mocks = new MockRepository();
            var products = mocks.Stub<IProductRepository>();

            using (mocks.Record())
            {
                SetupResult
                    .For(products.Get(1))
                    .IgnoreArguments()
                    .Return(new Product {Name = "Beer", Price = 12.99m});
            }

            // Test
            IProduct product1 = products.Get(2);
            Assert.AreEqual("Beer", product1.Name);

            IProduct product2 = products.Get(12);
            Assert.AreEqual("Beer", product2.Name);
        }

        private readonly IEnumerable<IProduct> _fakeProducts = new List<IProduct>
            {
                new Product {Name = "Steak", Price = 9.85m},
                new Product {Name = "Milk", Price = 2.02m},
                new Product {Name = "Diapers", Price = 33.07m}
            };
    }
}