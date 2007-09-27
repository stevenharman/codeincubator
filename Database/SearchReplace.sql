/*
*
* Search & Replace 
* As mentioned in original blog post here http://stevenharman.net/blog/archive/2007/02/02/Search_amp_Replace__For_Your_Database.aspx
*
* Use Ctrl+Shift+M to replace template values
*
*/
 
set xact_abort on
begin tran
 
declare @otxt varchar(1000)
set @otxt = '<string1, text, text to be replaced>'

declare @ntxt varchar(1000)
set @ntxt = '<string2, text, replacing text>'

declare @txtlen int
set @txtlen = len(@otxt)
 
declare @ptr binary(16)
declare @pos int
declare @id int
 
declare curs cursor local fast_forward
for
select 
	id,
	textptr(<field_name, sysname, target text field>),
	charindex(@otxt, <field_name, sysname, target text field>)-1
from 
	<table_name, sysname, target table> 
where 
	<field_name, sysname, target text field> 
like 
	'%' + @otxt +'%'
 
open curs
 
fetch next from curs into @id, @ptr, @pos

while @@fetch_status = 0
begin
	print 'Text found in row id=' + cast(@id as varchar) + ' at pos=' + cast(@pos as varchar)
	
	updatetext <table_name, sysname, target table>.<field_name, sysname, target text field> @ptr @pos @txtlen @ntxt

	fetch next from curs into @id, @ptr, @pos	
end
 
close curs
deallocate curs
PRINT 'Done!'
commit tran
