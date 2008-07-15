using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FakeContextTest
{
    [TestClass]
    public class Specification
    {
        protected virtual void Before_each_spec()
        {
            
        }

        protected virtual void After_each_spec()
        {
            
        }

        [TestInitialize]
        public void Setup()
        {
            Before_each_spec();
        }

        [TestCleanup]
        public void Cleanup()
        {
            After_each_spec();
        }
    }
}
