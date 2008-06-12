using CodeInc.Commons.Extensions.StructureMap;
using CodeInc.Commons.Testing;
using MbUnit.Framework;
using StructureMap;
using StructureMap.Configuration.DSL;

namespace Tests.CodeInc.Commons.Extensions.StructureMap
{
    [TestFixture]
    public class when_autowiring_interfaces_to_their_concrete_instancess_using_their_base_types : Specification
    {
        public override void before_each()
        {
            var registry = new TestRegistry();
            typeof (TestRegistry).Assembly.Autowire<IFooBase, FooBase>(registry);

            StructureMapConfiguration.ResetAll();
            StructureMapConfiguration.AddRegistry(registry);
            ObjectFactory.Reset();
        }

        public override void after_each()
        {
            StructureMapConfiguration.ResetAll();
            ObjectFactory.Reset();
        }

        [Test]
        public void then_should_find_a_concrete_instance_for_the_interface()
        {
            var foo = ObjectFactory.GetInstance<IFoo1>();

            foo.ShouldBeOfType(typeof (Foo1));
        }

        [Test]
        [ExpectedException(typeof (StructureMapException))]
        public void then_should_not_find_an_instance_of_the_base_interface()
        {
            ObjectFactory.GetInstance<IFooBase>();
        }

        [Test]
        public void then_should_find_a_concrete_instance_for_its_own_type()
        {
            var foo = ObjectFactory.GetInstance<Foo1>();

            foo.ShouldBeOfType(typeof (Foo1));
        }

        [Test]
        [ExpectedException(typeof (StructureMapException))]
        public void then_should_not_auto_wire_instances_of_a_non_subtypes_of_the_base_type()
        {
            ObjectFactory.GetInstance<IBar1>();
        }
    }

    #region Test interfaces and implementations

    public class TestRegistry : Registry
    {
    }

    public interface IFooBase
    {
        int DoSomething();
    }

    public abstract class FooBase : IFooBase
    {
        public virtual int DoSomething()
        {
            return 0;
        }
    }

    public interface IFoo1 : IFooBase
    {
        void DoSomethingElse();
    }

    public class Foo1 : FooBase, IFoo1
    {
        public virtual void DoSomethingElse()
        {
        }
    }

    public interface IBar1
    {
        int BarIt();
    }

    public class Bar1 : IBar1
    {
        public virtual int BarIt()
        {
            return 1;
        }
    }

    #endregion
}