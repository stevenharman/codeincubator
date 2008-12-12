class LogParse
	
	def has_service_name?(line)
		line.include? "realliving.webservices"
	end
	
	def split_service_line(line)
		line.split(',')
	end
	
	def get_service_name(serviceLine)
		serviceLine.split('.')[3]
	end
	
	def get_service_method_name(serviceLine)
		serviceLine.split('.')[4]
	end
end