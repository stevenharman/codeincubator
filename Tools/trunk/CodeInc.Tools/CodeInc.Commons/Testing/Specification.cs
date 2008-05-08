using System;
using MbUnit.Framework;
using Rhino.Mocks;

namespace CodeInc.Commons.Testing
{
    [TestFixture]
    public class Specification
    {
        private MockRepository _mocks;
        public MockRepository Mocks
        {
            get { return _mocks; }
        }

        public IDisposable PlaybackOnly
        {
            get
            {
                using (Record)
                {
                }
                return Playback;
            }
        }

        public void BackToRecord(object mockObject)
        {
            Mocks.BackToRecord(mockObject);
        }

        public IDisposable Record
        {
            get { return _mocks.Record(); }
        }

        public IDisposable Playback
        {
            get { return _mocks.Playback(); }
        }

        public T Create<T>()
        {
            return Mocks.DynamicMock<T>();
        }

        public T CreateStrictMock<T>()
        {
            return Mocks.CreateMock<T>();
        }

        [SetUp]
        public void Setup()
        {
            _mocks = new MockRepository();

            before_each();
        }

        public virtual void before_each()
        {
        }

        [TearDown]
        public void Teardown()
        {
            after_each();
        }

        public virtual void after_each()
        {
        }
    }
}