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

            Before_Each_Spec();
        }

        public virtual void Before_Each_Spec()
        {
        }

        [TearDown]
        public void Teardown()
        {
            After_Each_Spec();
        }

        public virtual void After_Each_Spec()
        {
        }
    }
}