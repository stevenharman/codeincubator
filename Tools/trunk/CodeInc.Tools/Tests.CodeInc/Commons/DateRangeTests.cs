using System;
using CodeInc.Commons;
using CodeInc.Commons.Testing;
using MbUnit.Framework;

namespace Tests.CodeInc.Commons
{
    [TestFixture]
    public class whan_a_new_date_range_has_a_start_and_end_dates : Specification
    {
        private DateTime _startDate;
        private DateTime _endDate;
        private DateRange _dateRange;

        public override void before_each()
        {
            base.before_each();
            _startDate = new DateTime(2008, 01, 01);
            _endDate = new DateTime(2008, 05, 05);
            _dateRange = new DateRange(_startDate, _endDate);
        }

        [Test]
        public void then_start_date_should_match()
        {
            _dateRange.Start.ShouldEqual(_startDate);
        }

        [Test]
        public void then_end_date_should_match()
        {
            _dateRange.End.ShouldEqual(_endDate);
        }

        [Test]
        public void then_the_duration_should_be_difference_between_the_start_and_end_dates()
        {
            _dateRange.Duration.ShouldEqual(_endDate - _startDate);
        }
    }

    [TestFixture]
    public class when_a_new_date_range_has_a_null_start : Specification
    {
        private DateTime _endDate;
        private DateRange _dateRange;

        public override void before_each()
        {
            base.before_each();

            _endDate = new DateTime(2008, 05, 05);
            _dateRange = new DateRange(null, _endDate);
        }

        [Test]
        public void then_start_date_should_be_the_minimum_date_value()
        {
            _dateRange.Start.ShouldEqual(DateTime.MinValue);
        }

        [Test]
        public void then_end_date_should_match()
        {
            _dateRange.End.ShouldEqual(_endDate);
        }

        [Test]
        public void then_the_duration_should_be_the_maximum_time_span()
        {
            _dateRange.Duration.ShouldEqual(TimeSpan.MaxValue);
        }
    }

    [TestFixture]
    public class when_a_new_date_range_has_a_null_end : Specification
    {
        private DateTime _startDate;
        private DateRange _dateRange;

        public override void before_each()
        {
            base.before_each();

            _startDate = new DateTime(2008, 01, 01);
            _dateRange = new DateRange(_startDate, null);
        }

        [Test]
        public void then_start_date_should_match()
        {
            _dateRange.Start.ShouldEqual(_startDate);
        }

        [Test]
        public void then_end_date_should_be_the_minimum_date_value()
        {
            _dateRange.End.ShouldEqual(DateTime.MaxValue);
        }

        [Test]
        public void then_the_duration_should_be_the_maximum_time_span()
        {
            _dateRange.Duration.ShouldEqual(TimeSpan.MaxValue);
        }
    }

    [TestFixture]
    public class when_a_new_date_range_has_a_null_start_and_end : Specification
    {
        private DateRange _dateRange;

        public override void before_each()
        {
            base.before_each();

            _dateRange = new DateRange(null, null);
        }

        [Test]
        public void then_start_date_should_be_the_minimum_date_value()
        {
            _dateRange.Start.ShouldEqual(DateTime.MinValue);
        }

        [Test]
        public void then_end_date_should_be_the_minimum_date_value()
        {
            _dateRange.End.ShouldEqual(DateTime.MaxValue);
        }

        [Test]
        public void then_the_duration_should_be_the_maximum_time_span()
        {
            _dateRange.Duration.ShouldEqual(TimeSpan.MaxValue);
        }
    }
}