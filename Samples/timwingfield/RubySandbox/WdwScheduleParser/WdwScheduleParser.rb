class WdwScheduleParser
	def get_reg_hours(line)
		cleaned = line.chomp.strip
		start = cleaned.index('>') + 1
		cleaned[start, cleaned.length]
	end
	
	def is_emh_line?(line)
		line.include? "<br>"
	end
	
	def get_hours_from_emh_line(line)
		start = line.index('>') + 1
		stop = line.index("<br>")
		line[start, stop]
	end
	
	def line_contains_hours?(line)
		line.include? "id=\"calendarText\""
	end
	
	def line_is_the_date_line?(line)
		line.include? "calendarOn"
	end
	
	def get_date_from_date_line(line)
		start = line.index("date=") + 1
		line[start, 10]
	end
end