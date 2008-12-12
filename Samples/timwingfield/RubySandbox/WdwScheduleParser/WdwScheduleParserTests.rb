require 'test/unit'
require "WdwScheduleParser"
class WdwScheduleParserTest < Test::Unit::TestCase
	
	@@f = File.open("wdw_mk_march09.htm")
	
	def test_file_is_loaded
		assert_not_nil(@@f)
	end
	
	def test_file_is_readable
		assert(File.readable?("wdw_mk_march09.htm"))
	end
	
	def test_wdwScheduleParser_is_not_nill
		assert_not_nil(WdwScheduleParser.new)
	end
	
	def test_simple_output
		wdw = WdwScheduleParser.new
		assert_equal(wdw.simpleOutput, "wdw")
	end
end