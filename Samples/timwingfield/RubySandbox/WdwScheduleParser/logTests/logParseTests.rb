require "test/unit"
require "LogParse"

class StringTest < Test::Unit::TestCase
	
	def setup
		@@logFile = File.open("reallivinglog.txt")	
		@@arr = IO.readlines("reallivinglog.txt")
		@@parser = LogParse.new
		
		@@serviceLine = @@arr[1]
	end
	
	def test_file_is_readable
		assert(File.readable?("reallivinglog.txt"))
	end
	
	def test_file_is_loaded
		assert_not_nil(@@logFile)
	end
	
	def test_can_read_first_line
		assert_not_nil(@@logFile.readline)
	end
	
	def test_line_contains_service_name
		assert(@@parser.has_service_name?(@@serviceLine))
	end
	
	def test_service_line_is_array
		assert(@@parser.split_service_line(@@serviceLine).length == 4)
	end
	
	def test_parse_service_name
		assert(@@parser.get_service_name(@@serviceLine) == "User")
	end
	
	def test_parse_service_method_name
		assert(@@parser.get_service_method_name(@@serviceLine[0].to_s) == "GetUser")
	end
	
	def test_parse_service_response_time
		flunk("Not yet implemented")
	end
		
	def teardown
		@@logFile.close
	end
	
end