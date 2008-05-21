using MbUnit.Framework;
using MvcApplication;
using Rhino.Mocks;

namespace MvcApplicationTest
{
    [TestFixture]
    public class RoverTests
    {
        [Test]
        public void BarkTestStrictReplay()
        {
            var mocks = new MockRepository();
            var rover = mocks.CreateMock<Rover>();

            using (mocks.Record())
            {
                rover.Bark(17);

                LastCall
                    .IgnoreArguments()
                    .Repeat.Times(2);
            }

            using (mocks.Playback())
            {
                rover.Bark(17);
                rover.Bark(23);
//                 rover.Bark(2); // fail
//                 rover.Fetch(2); // fail
            }
        }

        [Test]
        public void BarkTestLooseReplay()
        {
            var mocks = new MockRepository();
            var rover = mocks.DynamicMock<Rover>();

            using (mocks.Record())
            {
                rover.Bark(17);
                LastCall
                    .IgnoreArguments()
                    .Repeat.Times(2);
            }

            using (mocks.Playback())
            {
                rover.Bark(17);
                rover.Bark(23);
                rover.Bark(2); // pass
                rover.Fetch(2); // pass
            }
        }

        [Test]
        public void BarkTestPartialReplay()
        {
            var mocks = new MockRepository();
            var rover = mocks.PartialMock<Rover>();

            using (mocks.Record())
            {
                rover.Bark(17);
                LastCall
                    .IgnoreArguments()
                    .Repeat.Times(2);
            }

            using (mocks.Playback())
            {
                rover.Bark(17);
                rover.Bark(23);
                rover.Bark(2); // pass
                // rover.Fetch(2); // throws exception
            }
        }
    }
}