using MbUnit.Framework;
using MvcDemoApp.Models;
using System.Linq;

namespace MvcDemoAppTests.IntegrationTests
{
    [TestFixture]
    class NorthwindIntegrationTests
    {
        [Test]
        public void Should_Get_One_Customer()
        {
            var db = new NorthwindDataContext();
            var cust = db.Customers.Single(c => c.CustomerID == "ALFKI");

            Assert.IsNotNull(cust);
        }

        [Test]
        public void Should_Get_Orders_For_One_Customer()
        {
            var db = new NorthwindDataContext();
            var cust = db.Customers.Single(c => c.CustomerID == "ALFKI");

            var orders = db.Orders.Where(o => o.CustomerID == cust.CustomerID).ToList();

            Assert.IsNotNull(orders);
            Assert.GreaterThan(orders.Count, 0);
        }

        [Test]
        public void Should_Get_One_Product()
        {
            var db = new NorthwindDataContext();
            var prod = db.Products.Single(p => p.ProductID == 4);

            Assert.IsNotNull(prod);
        }
    }
}
