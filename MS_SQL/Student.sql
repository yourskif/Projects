----------------------------
-- Student
----------------------------

CREATE DATABASE Student
ON 
PRIMARY
 (
   NAME = Student,
   FILENAME = 'C:\Documents and Settings\Administrator\Мои документы\Student.mdf',
   SIZE = 2Mb,
   MAXSIZE = UNLIMITED,
   FILEGROWTH = 10% ),

FILEGROUP SECONDARY 
 (
   NAME = StudentSec,
   FILENAME = 'C:\Documents and Settings\Administrator\Мои документы\Student.ndf',
   SIZE = 2Mb,
   MAXSIZE = UNLIMITED,
   FILEGROWTH = 10% )
  
LOG ON 
(
   NAME = StudentLog,
   FILENAME = 'C:\Documents and Settings\Administrator\Мои документы\Student.ldf',
   SIZE = 2Mb,
   MAXSIZE = UNLIMITED,
   FILEGROWTH = 10% );

GO

----------------------------
----------------------------
----------------------------
-- Delete Drop Tables,Database
----------------------------
----------------------------
----------------------------
use Student
alter table st_grup_lib drop constraint St_grup_lib_FK1
alter table st_grup_lib drop constraint St_grup_lib_FK2
alter table st_grup_lib drop constraint St_grup_lib_FK3
alter table st_grup_lib drop constraint St_grup_lib_FK4
alter table st_grup_lib drop constraint St_grup_lib_FK5

alter table spec_sub_teach drop constraint spec_sub_teach_FK1
alter table spec_sub_teach drop constraint spec_sub_teach_FK2
alter table spec_sub_teach drop constraint spec_sub_teach_FK3
--drop table student,grup,spec,teacher,subject,exam,library,author,book,StGrant,st_grup_lib,spec_sub_teach
drop table st_grup_lib
drop table spec_sub_teach
drop table student
drop table grup
drop table spec
drop table teacher
drop table subject
drop table exam
drop table library
drop table author
drop table book
drop table StGrant

use master
GO
--EXEC DISCONNECT Student
drop database Student

----------------------------
----------------------------
----------------------------
-- Create Tables
----------------------------
----------------------------
----------------------------
USE Student

Create table dbo.student(
	id int identity(1,1) not null constraint StudentId primary key(id),
	fname varchar(25) not null,
	lname varchar(25) not null 
)
Create table dbo.grup(
	id int identity(1,1) not null constraint GrupId primary key(id),
	name varchar(25) not null constraint GrupUnique1 unique(name) ,
	main_student varchar(25) not null 
)
Create table dbo.spec(
	id int identity(1,1) not null constraint Spec1Id primary key(id),
	name varchar(25) not null constraint Spec1Unique1 unique(name) ,
)
Create table dbo.teacher(
	id int identity(1,1) not null constraint TeacherId primary key(id),
	fname varchar(25) not null,
	lname varchar(25) not null constraint TeacherUnigue1 unique(lname)
)
Create table dbo.subject(
	id int identity(1,1) not null constraint SubjectId primary key(id),
	name varchar(40) not null constraint SubjectUnique1 unique(name) ,
)
Create table dbo.exam(
	id int identity(1,1) not null constraint ExamId primary key(id),
	data_begin datetime,
	data_change datetime,
	mark int not null
)
Create table dbo.StGrant(
	id int identity(1,1) not null constraint StGrantId primary key(id),
	name varchar(40) not null constraint StGrantUnique1 unique(name) ,
	suma money
)
Create table dbo.library(
	id int identity(1,1) not null constraint LibraryId primary key(id),
	name varchar(25) not null constraint LibraryUnique1 unique(name) ,
)
Create table dbo.author(
	id int identity(1,1) not null constraint AuthorId primary key(id),
	name varchar(25) not null constraint AuthorUnique1 unique(name)
)

- Book ---------------------------------------------------------------------

use Student
--drop table book
select Id as id, 
	Name as Name, 
	Pages as Pages, 
	YearPress as YearPress,
	Comment as Comment,
	Quantity as Quantity 
	into dbo.book from dbo.Books
--SELECT * from dbo.book

use Student
--drop table author
select Id as id, 
	FirstName as FirstName,
	LastName as LastName
	into dbo.author from dbo.Authors
--SELECT * from dbo.author

use Student
--drop table category
select Id as id, 
	Name as Name
	into dbo.category from dbo.Categories
--SELECT * from dbo.category

use Student
--drop table pressa
select Id as id, 
	Name as Name
	into dbo.pressa from dbo.Press
--SELECT * from dbo.pressa

----------------------------
----------------------------
- CONSTRAINT ---------------
----------------------------
----------------------------
use Student
alter table spec_sub_teach drop constraint spec_sub_teach_FK1
alter table spec_sub_teach drop constraint spec_sub_teach_FK2
alter table spec_sub_teach drop constraint spec_sub_teach_FK3
use Student
drop table dbo.spec_sub_teach
Create table dbo.spec_sub_teach(
	id int identity(1,1) not null constraint Spec_sub_teachId primary key(id),
	id_spec int,
	id_teach int,
	id_sub int,
	Constraint spec_sub_teach_FK1 foreign key (id_spec)  References dbo.spec(id) On Update Cascade On Delete Cascade,
	Constraint spec_sub_teach_FK2 foreign key (id_teach) References dbo.teacher(id) On Update Cascade On Delete Cascade,
	Constraint spec_sub_teach_FK3 foreign key (id_sub) References dbo.subject(id) On Update Cascade On Delete Cascade
)

use Student
alter table st_grup_lib drop constraint St_grup_lib_FK1
alter table st_grup_lib drop constraint St_grup_lib_FK2
alter table st_grup_lib drop constraint St_grup_lib_FK3
alter table st_grup_lib drop constraint St_grup_lib_FK4
alter table st_grup_lib drop constraint St_grup_lib_FK5
use Student
drop table dbo.st_grup_lib
Create table dbo.st_grup_lib(
	id int identity(1,1) not null constraint Cards_bookId primary key(id),
	id_st int not null,
	id_grup int not null,
	id_exam int not null,
	id_lib int not null,
	id_grant int,
	id_spec_sub_teach int not null 
	Constraint Stud_gr_lib_FK1 foreign key (id_st)    References dbo.student(id) On Update Cascade On Delete Cascade,
	Constraint Stud_gr_lib_FK2 foreign key (id_grup)  References dbo.grup(id) On Update Cascade On Delete Cascade,
	Constraint Stud_gr_lib_FK3 foreign key (id_exam)  References dbo.exam(id) On Update Cascade On Delete Cascade,
	Constraint Stud_gr_lib_FK4 foreign key (id_lib)   References dbo.library(id) On Update Cascade On Delete Cascade,
	Constraint Stud_gr_lib_FK5 foreign key (id_grant) References dbo.StGrant(id) On Update Cascade On Delete Cascade,
	Constraint Stud_gr_lib_FK6 foreign key (id_spec_sub_teach) References dbo.spec_sub_teach(id) On Update Cascade On Delete Cascade
)

--Create table scards_book(
--	id int identity(1,1) not null constraint Scards_bookId primary key(id),
--	id_author int,
--	Constraint Books_FK1 foreign key (id_author) References authors (id) On Update Cascade 	On Delete Cascade
--)

----------------------------
----------------------------
----------------------------
-- INSERT
----------------------------
----------------------------
----------------------------
use Student
INSERT INTO dbo.student (fname, lname)   VALUES ('Сергей', 'Коноваленко');
INSERT INTO dbo.student (fname, lname)   VALUES ('Оксана', 'Коноваленко');
INSERT INTO dbo.student (fname, lname)   VALUES ('Тарас', 'Коноваленко');
INSERT INTO dbo.student (fname, lname)   VALUES ('Олена', 'Коноваленко');
INSERT INTO dbo.student (fname, lname)   VALUES ('Иван', 'Петров');
INSERT INTO dbo.student (fname, lname)   VALUES ('Василь', 'Колисниченко');
INSERT INTO dbo.student (fname, lname)   VALUES ('Николай', 'Колисниченко');
INSERT INTO dbo.student (fname, lname)   VALUES ('Вадим', 'Семиноженко');
INSERT INTO dbo.student (fname, lname)   VALUES ('Алла', 'Луговая');
SELECT * from dbo.student
--delete  from dbo.student

use Student
INSERT INTO dbo.grup (name, main_student)   VALUES ('10sp1', 'А.Луговая');
INSERT INTO dbo.grup (name, main_student)   VALUES ('10dz1', 'О.Коноваленко');
INSERT INTO dbo.grup (name, main_student)   VALUES ('10ad1', 'Н.Колисниченко');
INSERT INTO dbo.grup (name, main_student)   VALUES ('20sp1', 'И.Петров');
INSERT INTO dbo.grup (name, main_student)   VALUES ('20dz1', 'В.Семиноженко');
INSERT INTO dbo.grup (name, main_student)   VALUES ('30sp1', 'Т.Коноваленко')
SELECT * from dbo.grup
--delete  from dbo.grup

use Student
INSERT INTO dbo.spec (name)   VALUES ('Программирование');
INSERT INTO dbo.spec (name)   VALUES ('Дизайн');
INSERT INTO dbo.spec (name)   VALUES ('Администрирование');
SELECT * from dbo.spec
--delete  from dbo.spec

use Student
INSERT INTO dbo.teacher (fname, lname)   VALUES ('Михаил', 'Доманский');
INSERT INTO dbo.teacher (fname, lname)   VALUES ('Мария', 'Копыко');
INSERT INTO dbo.teacher (fname, lname)   VALUES ('Олена', 'Васильева');
INSERT INTO dbo.teacher (fname, lname)   VALUES ('Роман', 'Мацкевич');
SELECT * from dbo.teacher
--delete  from dbo.teacher

use Student
INSERT INTO dbo.subject (name)   VALUES ('Администртрование Windows Xp ');
INSERT INTO dbo.subject (name)   VALUES ('Программирование Ms Sql server');
INSERT INTO dbo.subject (name)   VALUES ('Локальные сети');
INSERT INTO dbo.subject (name)   VALUES ('HTML');
INSERT INTO dbo.subject (name)   VALUES ('WinAPI');
INSERT INTO dbo.subject (name)   VALUES ('XML');
INSERT INTO dbo.subject (name)   VALUES ('Фотошоп');
INSERT INTO dbo.subject (name)   VALUES ('Си');
INSERT INTO dbo.subject (name)   VALUES ('С++');
use Student
SELECT * from dbo.subject
--delete  from dbo.subject


use Student
INSERT INTO dbo.library (name)   VALUES ('Библиотека ШАГ')
INSERT INTO dbo.library (name)   VALUES ('Библиотека академическая')
use Student
SELECT * from dbo.library
--delete  from dbo.library


use Student
INSERT INTO dbo.StGrant (name,suma)   VALUES ('обычная',300)
INSERT INTO dbo.StGrant (name,suma)   VALUES ('повышенная',500)
INSERT INTO dbo.StGrant (name,suma)   VALUES ('президентская',1000)
--SELECT * from dbo.StGrant
--delete  from dbo.StGrant


use Student
--drop table dbo.exam
INSERT INTO dbo.exam (data_begin,data_change,mark)   VALUES ('09-27-2009','',5)
INSERT INTO dbo.exam (data_begin,data_change,mark)   VALUES ('09-28-2009','',4)
INSERT INTO dbo.exam (data_begin,data_change,mark)   VALUES ('09-29-2009','',3)
INSERT INTO dbo.exam (data_begin,data_change,mark)   VALUES ('09-26-2009','',5)
INSERT INTO dbo.exam (data_begin,data_change,mark)   VALUES ('09-30-2009','',3)
INSERT INTO dbo.exam (data_begin,data_change,mark)   VALUES ('10-15-2009','',3)
INSERT INTO dbo.exam (data_begin,data_change,mark)   VALUES ('10-14-2009','',4)
INSERT INTO dbo.exam (data_begin,data_change,mark)   VALUES ('10-12-2009','',2)
INSERT INTO dbo.exam (data_begin,data_change,mark)   VALUES ('10-11-2009','',4)
--delete from dbo.exam
--SELECT * from dbo.exam
--SELECT * from dbo.grup
--SELECT * from dbo.exam
--SELECT * from dbo.library
--SELECT * from dbo.StGrant
--delete  from dbo.exam


use Student
--drop table dbo.spec_sub_teach
INSERT INTO dbo.spec_sub_teach (id_spec,id_teach,id_sub) VALUES (1,1,1)
INSERT INTO dbo.spec_sub_teach (id_spec,id_teach,id_sub) VALUES (2,2,2)
INSERT INTO dbo.spec_sub_teach (id_spec,id_teach,id_sub) VALUES (3,3,3)
INSERT INTO dbo.spec_sub_teach (id_spec,id_teach,id_sub) VALUES (1,4,4)
INSERT INTO dbo.spec_sub_teach (id_spec,id_teach,id_sub) VALUES (2,1,5)
INSERT INTO dbo.spec_sub_teach (id_spec,id_teach,id_sub) VALUES (3,2,6)
INSERT INTO dbo.spec_sub_teach (id_spec,id_teach,id_sub) VALUES (1,3,7)
INSERT INTO dbo.spec_sub_teach (id_spec,id_teach,id_sub) VALUES (2,4,1)
--SELECT * from dbo.spec_sub_teach
--select * from teacher
--select * from spec
--select * from subject



use Student
--drop table dbo.st_grup_lib
INSERT INTO dbo.st_grup_lib (id_st,id_grup,id_exam,id_lib,id_grant,id_spec_sub_teach)    VALUES (1,1,2,1,1,1)
INSERT INTO dbo.st_grup_lib (id_st,id_grup,id_exam,id_lib,id_grant,id_spec_sub_teach)   VALUES (2,2,3,1,1,2)
INSERT INTO dbo.st_grup_lib (id_st,id_grup,id_exam,id_lib,id_grant,id_spec_sub_teach)   VALUES (3,3,1,1,1,3)
INSERT INTO dbo.st_grup_lib (id_st,id_grup,id_exam,id_lib,id_grant,id_spec_sub_teach)   VALUES (4,4,5,1,2,4)
INSERT INTO dbo.st_grup_lib (id_st,id_grup,id_exam,id_lib,id_grant,id_spec_sub_teach)   VALUES (5,5,6,1,1,5)
INSERT INTO dbo.st_grup_lib (id_st,id_grup,id_exam,id_lib,id_grant,id_spec_sub_teach)   VALUES (6,6,7,1,1,6)
INSERT INTO dbo.st_grup_lib (id_st,id_grup,id_exam,id_lib,id_grant,id_spec_sub_teach)   VALUES (7,1,8,1,1,7)
INSERT INTO dbo.st_grup_lib (id_st,id_grup,id_exam,id_lib,id_grant,id_spec_sub_teach)   VALUES (8,2,9,2,3,8)
INSERT INTO dbo.st_grup_lib (id_st,id_grup,id_exam,id_lib,id_grant,id_spec_sub_teach)   VALUES (9,3,10,2,1,1)
--SELECT * from dbo.spec_sub_teach
--SELECT * from dbo.st_grup_lib


----------------------------
----------------------------
----------------------------
-- REQUESTS
----------------------------
----------------------------
----------------------------


--Система повинна видавати звіти : 
--O	список студентів по групах;
--O	список студентів які мають рейтинг від X до Y;
--O	список студентів та книг що не повернені більше року (з підсумовуванням кількості книг та грошового боргу студента);
--O	довідка для студента про його рейтинг та розмір стипендії;
--O	Список студентів, які здали екзамен на п’ять, в якого викладача і з якого предмета;
--O	Список студентів які не здали екзамен, в якого викладача і з якого предмета;
--O	Список студентів студентів, яких потрібно відрахувати (студента потрібно відрахувати, якщо він не здав більше 3 –х екзаменів на протязі однієї сесії);
--O	Інформацію про викладача, який поклав найбільшу кількість талонів. 


--O	список студентів по групах;
select student.*,grup.[sname]
from student RIGHT JOIN st_grup_lib ON (st_grup_lib.id_st=student.id)
RIGHT JOIN grup ON (st_grup_lib.id_grup=grup.id) 

--O	список студентів які мають рейтинг від X до Y;
select student.*,exam.[mark]
from student RIGHT JOIN st_grup_lib ON (st_grup_lib.id_st=student.id)
RIGHT JOIN exam ON (st_grup_lib.id_exam=exam.id) order by exam.[mark] DESC
--O	довідка для студента про його рейтинг та розмір стипендії;
select 	student.[id] as [номер], 
	student.[fname] as [имя], 
	student.[lname] as [фамилия],
	exam.[mark],	
	StGrant.[name] as [стипендия],
	StGrant.[suma] as [сумма],
	grup.[name] as [группа]
from student LEFT JOIN st_grup_lib ON (st_grup_lib.id_st=student.id)
LEFT JOIN exam ON (st_grup_lib.id_exam=exam.id) 
LEFT JOIN grup ON (st_grup_lib.id_grup=grup.id) 
LEFT JOIN StGrant ON (st_grup_lib.id_grant=StGrant.id) 
--select * from dbo.StGrant
--SELECT * from dbo.st_grup_lib


--O	Список студентів, які здали екзамен на п’ять, в якого викладача і з якого предмета;
use Student
select 	student.[id] as [номер], student.[fname] as [имя], student.[lname] as [фамилия],exam.[mark],grup.[name] as [группа],teacher.*,subject.*     --.name as [преподаватель]
from student LEFT JOIN st_grup_lib ON (st_grup_lib.id_st=student.id)
LEFT JOIN exam ON (st_grup_lib.id_exam=exam.id) 
LEFT JOIN grup ON (st_grup_lib.id_grup=grup.id)
LEFT JOIN spec_sub_teach ON (spec_sub_teach.id=st_grup_lib.id_spec_sub_teach)
LEFT JOIN teacher ON (spec_sub_teach.id_teach=teacher.id)
LEFT JOIN subject ON (spec_sub_teach.id_sub=subject.id)
WHERE (exam.mark=5)

--O	Список студентів які не здали екзамен, в якого викладача і з якого предмета;
use Student
select 	student.[id] as [номер], student.[fname] as [имя], student.[lname] as [фамилия],exam.[mark],grup.[name] as [группа],teacher.*,subject.*     --.name as [преподаватель]
from student LEFT JOIN st_grup_lib ON (st_grup_lib.id_st=student.id)
LEFT JOIN exam ON (st_grup_lib.id_exam=exam.id) 
LEFT JOIN grup ON (st_grup_lib.id_grup=grup.id)
LEFT JOIN spec_sub_teach ON (spec_sub_teach.id=st_grup_lib.id_spec_sub_teach)
LEFT JOIN teacher ON (spec_sub_teach.id_teach=teacher.id)
LEFT JOIN subject ON (spec_sub_teach.id_sub=subject.id)
WHERE (exam.mark=2)
--O	Список студентів студентів, яких потрібно відрахувати (студента потрібно відрахувати, якщо він не здав більше 3 –х екзаменів на протязі однієї сесії);
--O	Інформацію про викладача, який поклав найбільшу кількість талонів. 

--O	список студентів та книг що не повернені більше року (з підсумовуванням кількості книг та грошового боргу студента);
