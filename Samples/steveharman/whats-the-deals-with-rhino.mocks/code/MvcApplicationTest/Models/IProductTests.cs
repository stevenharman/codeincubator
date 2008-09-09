using MbUnit.Framework;
using MvcApplication.Models;
using Rhino.Mocks;

namespace MvcApplicationTest.Models
{
    [TestFixture]
    public class IProductTests
    {
        [Test]
        public void TestStubInterface()
        {
            decimal price = 3200.00m;

            // Setup product stub
            IProduct product = MockRepository.GenerateStub<IProduct>();
            product.Name = "Laptop Computer";
            product.Price = price;

            // Call method being tested
            ProductManager.DoublePrice(product);

            // Test
            Assert.AreEqual(price * 2, product.Price);
        }
    }
}