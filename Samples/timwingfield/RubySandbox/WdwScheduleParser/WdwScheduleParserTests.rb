require 'test/unit'
require "WdwScheduleParser"
class WdwScheduleParserTest < Test::Unit::TestCase
	
	@@a = IO.readlines("wdw_mk_march09.htm")
	
	@@emhLine = @@a[768]
	@@regLine = @@a[773]
	@@dateLine = @@a[767]
	@@hours = "9:00am - 8:00pm"
	@@date = "03/01/2009"
	@@wdw = WdwScheduleParser.new
	
	def test_file_is_readable
		assert(File.readable?("wdw_mk_march09.htm"))
	end
	
	def test_get_hours_from_regular_line
		assert(@@wdw.get_reg_hours(@@regLine), @@hours)
	end
	
	def test_is_emh_line
		assert(@@wdw.is_emh_line?(@@emhLine))
	end
	
	def test_is_not_emh_line
		assert(!@@wdw.is_emh_line?(@@regLine))
	end
	
	def test_get_hours_from_emh_line
		assert(@@wdw.get_hours_from_emh_line(@@emhLine), @@hours)
	end
	
	def test_line_contains_hours
		assert(@@wdw.line_contains_hours?(@@emhLine))
	end
	
	def test_line_does_not_contain_hours
		assert(!@@wdw.line_contains_hours?(@@a[770]))
	end
	
	def test_line_is_the_date_line
		assert(@@wdw.line_is_the_date_line?(@@dateLine))
	end
	
	def test_line_is_not_the_date_line
		assert(!@@wdw.line_is_the_date_line?(@@emhLine))
	end
	
	def test_get_date_from_date_line
		assert(@@wdw.get_date_from_date_line(@@dateLine))
	end
	
end