using System;
using System.Collections.Generic;
using CodeInc.Commons.Extensions;
using MbUnit.Framework;
using Rhino.Mocks;

namespace Tests.CodeInc.Commons.Extensions
{
    public class When_Executing_Each_On_IEnumerable_That_Is_Null : SpecBase
    {
        [Test]
        [ExpectedArgumentNullException]
        public void Should_Throw_NullArgumentException()
        {
            IEnumerable<ITestWidget> widgets = null;

            widgets.Each(w =>
            {
                w.Foo();
            });
        }
    }

    public class When_Executing_Each_On_IEnumerable_That_Has_Items : SpecBase
    {
        [Test]
        public void Should_Executes_CodeBlock_On_Every_Item()
        {
            ITestWidget myWidget = Create<ITestWidget>();
            IEnumerable<ITestWidget> widgets = new ITestWidget[] { myWidget, myWidget, myWidget, myWidget, myWidget };

            using (Record)
            {
                Expect.Call(myWidget.Foo()).Return("I was called!").Repeat.Times(5);
            }

            using (Playback)
            {
                widgets.Each(w =>
                {
                    string output = w.Foo();
                    Console.WriteLine(output);
                });
            }
        }
    }

    public interface ITestWidget
    {
        string Foo();
    }
}