create database MVC_Application_DB
use MVC_Application_DB

create table user_Information(
uid int primary key identity,
name varchar(50),
city varchar(50),
age int
)

alter table user_Information add country int
alter table user_Information add state int

select * from user_Information
-------------------------------------------------------------------------
--Procedures:-

alter proc user_insert
@name varchar(50),
@city varchar(50),
@age int,
@country int,
@state int
as
begin
insert into user_Information
(name,city,age,country,state) values (@name,@city,@age,@country,@state)
end


alter proc user_show
as
begin
select * from user_Information join tblcountry on country=cid join tblstate on state=sid
end


create proc user_delete
@id int
as
begin
delete from user_Information where uid=@id
end

create proc user_edit
@id int
as
begin
select *  from user_Information where uid=@id
end


alter proc user_update
@uid int,
@name varchar(50),
@city varchar(50),
@age int,
@country int,
@state int
as
begin
update user_Information set name=@name,city=@city,age=@age,country=@country,state=@state where uid=@uid
end

-- ---------------------Drop Down-----------------------------

create table tblcountry(
cid int primary key identity,
cname varchar(50)
)

insert into tblcountry (cname)values('India'),('Pakistan'),('USA')
select * from tblcountry

create proc form_country
as
begin
select * from tblcountry
end



create table tblstate(
sid int primary key identity,
cid int,
sname varchar(50)
)

insert into tblstate (cid,sname) values
(1,'UP'),(1,'Bihar'),(1,'Jhartkhand'),(1,'Maharastra'),(2,'Khayber'),(2,'Sindh'),
(3,'Las Vegas'),(3,'California'),(3,'Taxas')

select * from tblstate

alter proc form_state
@cid int
as
begin
select * from tblstate where cid=@cid
end

sp_helptext form_state