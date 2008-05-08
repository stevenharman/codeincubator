using System;
using System.Collections.Generic;
using System.Linq;
using CodeInc.Commons.Extensions;
using CodeInc.Commons.Testing;
using MbUnit.Framework;
using Rhino.Mocks;

namespace Tests.CodeInc.Commons.Extensions
{
    public class when_executing_Each_on_IEnumerable_that_is_null : Specification
    {
        private IEnumerable<ITestWidget> _widgets;

        public override void Before_Each_Spec()
        {
            _widgets = null;
        }

        [Test]
        [ExpectedArgumentNullException]
        public void then_should_throw_NullArgumentException()
        {
            _widgets.Each(w =>
            {
                w.Foo();
            });
        }
    }

    public class when_executing_Each_on_IEnumerable_that_has_items 
        : behaves_like_context_where_IEnumerable_has_items
    {
        [Test]
        public void then_should_executes_codeblock_on_every_item()
        {
            using (Record)
            {
                Expect.Call(_theWidget.Foo()).Return("I was called!").Repeat.Times(5);
            }

            using (Playback)
            {
                _widgets.Each(w =>
                {
                    string output = w.Foo();
                    Console.WriteLine(output);
                });
            }
        }
    }

    public class when_checking_if_IEnumerable_is_empty
        : behaves_like_context_where_IEnumerable_has_items
    {
        [Test]
        public void then_should_not_be_empty()
        {
            _widgets.IsEmpty().ShouldBeFalse();
        }
    }

    [TestFixture]
    public abstract class behaves_like_context_where_IEnumerable_has_items : Specification
    {
        protected IEnumerable<ITestWidget> _widgets;
        protected ITestWidget _theWidget;

        public override void Before_Each_Spec()
        {
            _theWidget = Create<ITestWidget>();
            _widgets = Enumerable.Repeat(_theWidget, 5);
        }
    }

    public interface ITestWidget
    {
        string Foo();
    }
}