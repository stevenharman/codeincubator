using CodeInc.Commons;
using CodeInc.Commons.Testing;
using MbUnit.Framework;

namespace Tests.CodeInc.Commons
{
    [TestFixture]
    public class when_constructing_Range_with_smaller_first_item 
        : behaves_like_context_with_range
    {
        public override void before_each()
        {
            _first = SpecHelper.RandomInt(-9999, 9999);
            _second = SpecHelper.RandomInt(_first, int.MaxValue);
            _range = new Range<int>(_first, _second);
        }

        [Test]
        public void then_Start_should_be_the_first_item_and_End_is_the_second_item()
        {
            _range.Start.ShouldEqual(_first);
            _range.End.ShouldEqual(_second);
        }
    }

    [TestFixture]
    public class when_constructing_Range_with_smaller_second_item 
        : behaves_like_context_with_range
    {
        public override void before_each()
        {
            _second = SpecHelper.RandomInt(-9999, 9999);
            _first = SpecHelper.RandomInt(_second, int.MaxValue);
            _range = new Range<int>(_first, _second);
        }

        [Test]
        public void then_Start_should_be_the_second_item_and_End_is_the_first_item()
        {
            _range.Start.ShouldEqual(_second);
            _range.End.ShouldEqual(_first);
        }
    }

    public class behaves_like_context_with_range : Specification
    {
        protected int _first;
        protected int _second;
        protected Range<int> _range;
    }
}