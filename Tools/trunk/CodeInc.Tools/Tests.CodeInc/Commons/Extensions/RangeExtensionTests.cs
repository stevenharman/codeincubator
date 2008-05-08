using CodeInc.Commons;
using CodeInc.Commons.Extensions;
using CodeInc.Commons.Testing;
using MbUnit.Framework;

namespace Tests.CodeInc.Commons.Extensions
{
    [TestFixture]
    public class when_left_range_is_completely_before_right : RangeExtensionSpecification
    {
        public override void before_each()
        {
            _left = new Range<int>(RandNegative, -1);
            _right = new Range<int>(1, int.MaxValue);
        }

        [Test]
        public void then_ranges_do_not_overlap()
        {
            _left.Overlaps(_right).ShouldBeFalse();
        }
    }

    [TestFixture]
    public class when_both_ranges_have_same_start : RangeExtensionSpecification
    {
        public override void before_each()
        {
            _left = new Range<int>(1, RandPositive);
            _right = new Range<int>(1, RandPositive);
        }

        [Test]
        public void then_ranges_do_overlap()
        {
            _left.Overlaps(_right).ShouldBeTrue();
        }
    }

    [TestFixture]
    public class when_left_range_starts_after_the_right_starts : RangeExtensionSpecification
    {
        public override void before_each()
        {
            _right = new Range<int>(100, 500);
        }

        [Test]
        public void and_before_right_ends_then_should_overlap()
        {
            _left = new Range<int>(_right.Start + 1, SpecHelper.RandomInt(251, 9999));

            _left.Overlaps(_right).ShouldBeTrue();
        }

        [Test]
        public void and_after_right_ends_then_should_not_overlap()
        {
            _left = new Range<int>(_right.End + 1, _right.End + 2);
        }
    }

    [TestFixture]
    public class when_right_starts_before_left_ends : RangeExtensionSpecification
    {
        public override void before_each()
        {
            _left = new Range<int>(RandNegative, SpecHelper.RandomInt(100));
            _right = new Range<int>(_left.End - 1, SpecHelper.RandomInt(101, 9999));
        }

        [Test]
        public void then_should_be_overlap()
        {
            _left.Overlaps(_right).ShouldBeTrue();
        }
    }

    public class RangeExtensionSpecification : Specification
    {
        protected Range<int> _left;
        protected Range<int> _right;

        protected static int RandPositive
        {
            get { return SpecHelper.RandomInt(1, int.MaxValue); }
        }

        protected static int RandNegative
        {
            get { return -1 * RandPositive; }
        }
    }
}