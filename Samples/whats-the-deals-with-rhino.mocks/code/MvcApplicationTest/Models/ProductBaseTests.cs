using MbUnit.Framework;
using MvcApplication.Models;
using Rhino.Mocks;

namespace MvcApplicationTest.Models
{
    [TestFixture]
    public class ProductBaseTests
    {
        [Test]
        public void TestStubAbstract()
        {
            // Setup product stub
            ProductBase product = MockRepository.GenerateStub<ProductBase>();
            product.Name = "Laptop Computer";
            product.Price = 3200.00m;

            // Test
            Assert.AreEqual(3200.00m, product.Price);
        }
    }
}