select distinct name from tableA where name not in (select distinct name from tableA where fenshu<=80)

select name from tableA group by name having min(fenshu)>80


delete from tableB where id not in(select min(id) from tableB group by xuehao,name,courseId,courseName,fenshu)


 select year
 , sum(case when month=1 then amount else 0 end) as m1
 , sum(case when month=2 then amount else 0 end) as m2
 , sum(case when month=3 then amount else 0 end) as m3
 , sum(case when month=4 then amount else 0 end) as m4
 from bbb group By year


select year
,(select amount from aaa m where month=1 and m.year=aaa.year) as m1
,(select amount from aaa m where month=2 and m.year=aaa.year) as m2
,(select amount from aaa m where month=3 and m.year=aaa.year) as m3
,(select amount from aaa m where month=4 and m.year=aaa.year) as m4
from aaa group by year



select (case when yuwen>=80 then 'youxiu' 
			when yuwen>=60 then 'jige'
			else 'bujige' end) as yuwen,
			(case when shuxue>=80 then 'youxiu' 
			when shuxue>=60 then 'jige'
			 else 'bujige' end) as shuxue,
			(case when yingyu>=80 then 'youxiu' 
			 when yingyu>=60 then 'jige'
			 else 'bujige' end) as yingyu
			from score

select top 10 * from A where id not in (select top 30 id from A)

select * from (select count(id) as count from A group by id) T where t.count>3

