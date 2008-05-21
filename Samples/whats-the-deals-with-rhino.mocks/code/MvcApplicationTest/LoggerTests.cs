using MbUnit.Framework;
using MvcApplication;
using MvcApplication.Models;
using Rhino.Mocks;

namespace MvcApplicationTest
{
    [TestFixture]
    public class LoggerTests
    {
        [Test]
        public void LogTest()
        {
            var mocks = new MockRepository();
            var logger = mocks.CreateMock<Logger>();

            using (mocks.Record())
            {
                logger.Log(27);
            }

            using (mocks.Playback())
            {
                var newCustomer = new Customer(27, logger);
                newCustomer.Name = "Stephen Walther";

                // I would never really do this!
                newCustomer.Save();
            }
        }
    }
}