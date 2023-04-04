use master;

if db_id('BD_Project') is not null drop database BD_Project;

IF @@ERROR = 3702 
   RAISERROR('Database cannot be dropped because there are still open connections.', 127, 127) WITH NOWAIT, LOG;

create database BD_Project;
go

use BD_Project;
go

drop table if exists Users
drop table if exists Notes
drop table if exists SharedNotes
go

create table Users(
	userid int not null identity,
	username nvarchar(50) not null,
	gender nvarchar(10) not null check (gender in('Male', 'Female')),
	birthdate datetime not null,

	primary key (userid)
);

create table Notes(
	noteid int not null identity,
	userid int not null,
	subject nvarchar(30),
	content nvarchar(100),
	date datetime not null,

	primary key (noteid),
	foreign key (userid) references Users(userid),
);

create table SharedNotes(
	id int not null identity,
	fromuserid int not null,
	touserid int not null,
	noteid int not null,
	date datetime not null,

	primary key (id),
	foreign key (fromuserid) references Users(userid),
	foreign key (touserid) references Users(userid),
	foreign key (noteid) references Notes(noteid)
);
go

create or alter procedure CreateData(
	@fromusername varchar(50),
	@tousername varchar(50),
	@subject varchar(30),
	@content varchar(100)
)
as
begin
	declare @fromuserid int = (select userid from Users where username = @fromusername)
	declare @touserid int = (select userid from Users where username = @tousername)

	insert into Notes (userid, subject, content, date)
	values (@fromuserid, @subject, @content, GETDATE())

	declare @noteid int = (select noteid from Notes where subject = @subject and userid = @fromuserid)

	insert into SharedNotes (fromuserid, touserid, noteid, date)
	values (@fromuserid, @touserid, @noteid, GETDATE())
end
go

create or alter procedure ReadData
as
begin
	select sn.id as 'id', uF.username as 'From', uT.username as 'To', n.subject as 'Subject', n.content as 'Content'
	from SharedNotes sn
	join Users uF on uF.userid = sn.fromuserid
	join Users uT on ut.userid = sn.touserid
	join Notes n on n.noteid = sn.noteid
end
go

create or alter procedure UpdateData(
	@id int,
	@fromusername varchar(50),
	@tousername varchar(50),
	@subject varchar(30),
	@content varchar(100)
)
as
begin
	declare @fromuserid int = (select userid from Users where username = @fromusername)
	declare @touserid int = (select userid from Users where username = @tousername)
	declare @noteid int = (select noteid from Notes where noteid = @id)

	update Notes
	set userid = @fromuserid, subject = @subject, content = @content, date = GETDATE()
	where noteid = @id

	update SharedNotes
	set fromuserid = @fromuserid, touserid = @touserid, noteid = @noteid, date = GETDATE()
	where id = @id
end
go

create or alter procedure DeleteData(
	@id int
)
as
begin
	delete from SharedNotes where id = @id
	delete from Notes where noteid = @id
end
go

create or alter procedure GetName(
	@i int
)
as
begin
	if (@i = 1) select username from Users

	if (@i = 2) select username from Users
end
go

create or alter procedure FindNotes(
	@fromusername varchar(50)
)
as
begin
	select sn.id as 'id', uF.username as 'From', uT.username as 'To', n.subject as 'Subject', n.content as 'Content'
	from SharedNotes sn
	join Users uF on uF.userid = sn.fromuserid
	join Users uT on ut.userid = sn.touserid
	join Notes n on n.noteid = sn.noteid
	where uF.username = @fromusername
end
go

insert into Users(username, gender, birthdate)
values ('User 1', 'Female', '2003-06-05'),
	   ('User 2', 'Male', '2002-02-04'),
	   ('User 3', 'Male', '1967-05-19'),
	   ('User 4', 'Female', '1965-03-27'),
	   ('User 5', 'Female', '2022-01-01')
go

insert into Notes(userid, subject, content, date)
values (1, 'Documents', 'Please bring the documents to office 100', GETDATE()),
	   (4, 'Shopping', 'Apples', '2023-02-22'),
	   (2, 'Game', 'Deadline: March 10', '2023-02-22'),
	   (5, 'Test', 'Test', '2022-01-01')
go

insert into SharedNotes(fromuserid, touserid, noteid, date)
values (1, 2, 1, GETDATE()),
	   (4, 3, 2, '2023-02-23'),
	   (2, 1, 3, '2023-02-28'),
	   (5, 5, 4, '2023-01-01')
go