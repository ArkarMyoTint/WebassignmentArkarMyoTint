Create Database StarLightTickets

--/////////////////////////////////Cinema/////////////////////////////////////////////
create table Cinema_fix(
CID int primary key,
Cinemaname varchar(50),
Location varchar(50),
Lng varchar(50),
Lat varchar(50)
)
select *from Cinema_fix
insert INTO Cinema_fix values (1,'JCGV-1','Junction City','96.1539','16.7791')
insert INTO Cinema_fix values (2,'JCGV-2','City Mall St. John','96.1447','16.7829')
insert INTO Cinema_fix values (3,'JCGV-3','Junction Square','96.1311','16.8173')
insert INTO Cinema_fix values (4,'Mingalar Cineplex','Sanpya','96.1448','16.7775')
insert INTO Cinema_fix values (5,'Mingalar Cineplex','Shwedagon','96.1531','16.7765')
insert INTO Cinema_fix values (6,'Mingalar Cineplex','Ga Mone Pwint','96.1296','16.8330')
insert INTO Cinema_fix values (7,'Mingalar Cineplex','Dagon Center 2','96.1374','16.8045')
insert INTO Cinema_fix values (8,'Nay Pyi Thaw Cinema','Sule','96.1593','16.7785')
insert INTO Cinema_fix values (9,'Thamada Cinema','Alan Pya Pagoda St','96.1588','16.7824')

create table Cinema(
Id int primary key,
Cid int,
CinemaName varchar(50),
ShowDate date,
Quantity int check (Quantity>=0),
MovieName varchar(30),
Price int,
Constraint Fk_id foreign key (Cid) References  Cinema_fix(CID),
)


select*from Cinema

insert INTO Cinema values (1,9,'Thamada Cinema','2/5/2019',30,'Captain Marvel',3500)
insert INTO Cinema values (2,9,'Thamada Cinema','2/5/2019',10,'Captain Marvel',4000)
insert INTO Cinema values (3,1,'JCGV-2','2/5/2019',10,'Alita: Battle Angel',3000)
insert INTO Cinema values (4,1,'JCGV-1','2/5/2019',15,'Alita: Battle Angel',4000)




create table Cinema_Save(
CID_save int primary key IDENTITY(1,1),
CinemaID int,
UserName nvarchar(256),
CinemaName varchar(50),
MovieName varchar(30),
Location varchar(50),
ShowDate date,
Quantity int,
Price int,
Toatal as Quantity*Price,
Constraint Fk_userid foreign key (UserName) References dbo.AspNetUsers(UserName),
Constraint Fk_CIDd foreign key (CinemaID) References Cinema(Id)
)



create trigger booking on Cinema_Save 
after insert as 
declare @id int
set @id=(select CID_save from inserted)
declare @cid int
set @cid=(select CinemaID from inserted)
declare @cinemaid int
set @cinemaid=(select Id from Cinema where Id=@cid)
declare @qty int
set @qty=(select Quantity from inserted)
declare @CQTY int
set @CQTY=(select Quantity from Cinema where Id=@cid)


update Cinema
set Quantity=@CQTY-@qty
where Id=@cinemaid


--drop trigger booking

select*from Cinema
insert INTO Cinema_Save values (1,'arkarmyotint99@gmail.com','Thamada Cinema','Captain Marvel','Alan Pya Pagoda St','2/5/2019',1,3500)
insert INTO Cinema_Save values (1,'arkarmyotint99@gmail.com','Thamada Cinema','Captain Marvel','Alan Pya Pagoda St','2/5/2019',2,3500)
--/////////////////////////////////Cinema///////////////////////////////////////////
--/////////////////////////////////admin and normal user////////////////////////////
insert dbo.AspNetRoles values ('A','Admin')
insert dbo.AspNetUserRoles values ('446205c7-d697-4496-b51e-b50db0be488a','A')
--/////////////////////////////////admin and normal user////////////////////////////


--/////////////////////////////////Theatre//////////////////////////////////////////
create table Theatre_fix(
TID int primary key,
Theatrename varchar(50),
Location varchar(50),
Lng varchar(50),
Lat varchar(50)
)
insert INTO Theatre_fix values (1,'National Theatre','Myo Ma Kyaung Rd','96.1487','16.7839')
insert INTO Theatre_fix values (2,'HTWE OO MYANMAR','No.(12)(1Floor/Left), Yama Street','96.1293','16.7842')

select*from Theatre_fix


create table Theatre(
Id int primary key,
Tid int,
TheatreName varchar(50),
ShowDate date,
Quantity int check (Quantity>=0),
Play varchar(30),
Price int,
Constraint Fk_tid foreign key (Tid) References  Theatre_fix(TID),
)
insert INTO Theatre values (1,2,'HTWE OO MYANMAR','3/10/2019',30,'5 Star A Nyeint',3500)
insert INTO Theatre values (2,1,'National Theatre','3/5/2019',10,'Nin Ci A Nyeint',4000)
insert INTO Theatre values (3,1,'National Theatre','3/11/2019',15,'ALBA School Union',3000)

select *from Theatre

create table Theatre_Save(
TID_save int primary key IDENTITY(1,1),
TheatreID int,
UserName nvarchar(256),
TheatreName varchar(50),
Play varchar(30),
Location varchar(50),
ShowDate date,
Quantity int,
Price int,
Toatal as Quantity*Price,
Constraint Fk_usertid foreign key (UserName) References dbo.AspNetUsers(UserName),
Constraint Fk_TIDd foreign key (TheatreID) References Theatre(Id)
)
select*from Theatre_Save

create trigger tbooking on Theatre_Save
after insert as 
declare @id int
set @id=(select TID_save from inserted)
declare @tid int
set @tid=(select TheatreID from inserted)
declare @theaid int
set @theaid=(select Id from Theatre where Id=@tid)
declare @qty int
set @qty=(select Quantity from inserted)
declare @CQTY int
set @CQTY=(select Quantity from Theatre where Id=@tid)
update Theatre
set Quantity=@CQTY-@qty
where Id=@theaid

select*from Theatre
select*from Theatre_Save
insert INTO Theatre_Save values (1,'arkarmyotint99@gmail.com','Thamada Cinema','Captain Marvel','Alan Pya Pagoda St','2/5/2019',2,3500)
--/////////////////////////////////////////Theatre//////////////////////////////////////////

--/////////////////////////////////////////Sports///////////////////////////////////////////
create table Sport_fix(
SID int primary key,
Sporttheatre varchar(50),
Location varchar(50),
Lng varchar(50),
Lat varchar(50)
)
insert INTO Sport_fix values (1,'Thuwunna Stadium','Thuwunna, Yangon','96.1868','16.8213')
insert INTO Sport_fix values (2,'Aung San Football Stadium','Yangon','96.1608','16.7840')
insert INTO Sport_fix values (3,'Phoenix Myanmar Lethwei Gym',' Thein Phyu Stadium,Thein Phyu Road','96.1675','16.7922')

select*from Sport_fix


create table Sport(
Id int primary key,
Sid int,
SportTheatre varchar(50),
ShowDate date,
Quantity int check (Quantity>=0),
Play varchar(30),
Price int,
Constraint Fk_sid foreign key (Sid) References  Sport_fix(SID),
)
insert INTO Sport values (1,1,'Thuwunna Stadium','3/1/2019',10,'Myanmar Vs Thai',3500)
insert INTO Sport values (2,2,'Aung San Football Stadium','3/7/2019',10,'Yangon Vs Mandalay',4000)
insert INTO Sport values (3,3,'Phoenix Myanmar Lethwei Gym','3/12/2019',15,'Gusto Vs MIC',4000)

select *from Sport

create table Sport_Save(
SID_save int primary key IDENTITY(1,1),
SportID int,
UserName nvarchar(256),
SportTheatre varchar(50),
Sportname varchar(30),
Location varchar(50),
ShowDate date,
Quantity int,
Price int,
Toatal as Quantity*Price,
Constraint Fk_usersid foreign key (UserName) References dbo.AspNetUsers(UserName),
Constraint Fk_SIDd foreign key (SportID) References Sport(Id)
)
select*from Sport_Save

create trigger sbooking on Sport_Save
after insert as 
declare @id int
set @id=(select SID_save from inserted)
declare @sid int
set @sid=(select SportID from inserted)
declare @spoid int
set @spoid=(select Id from Sport where Id=@sid)
declare @qty int
set @qty=(select Quantity from inserted)
declare @CQTY int
set @CQTY=(select Quantity from Sport where Id=@sid)
update Sport
set Quantity=@CQTY-@qty
where Id=@spoid

insert INTO Sport_Save values (1,'arkarmyotint99@gmail.com','Thamada Cinema','Captain Marvel','Alan Pya Pagoda St','2/5/2019',2,3500)
--//////////////////////////////////////////Sports/////////////////////////////////////////
select*from dbo.AspNetUsers




select*from Cinema_fix
select*from Cinema
select*from Cinema_Save

select*from Theatre_fix
select*from Theatre
select*from Theatre_Save

select*from Sport_fix
select*from Sport
select*from Sport_Save

delete from Cinema_fix
delete from Cinema
delete from Cinema_Save

delete from Theatre_fix
delete from Theatre
delete from Theatre_Save

delete from Sport_fix
delete from Sport
delete from Sport_Save

drop table Cinema_fix
drop table Cinema
drop table Cinema_Save

drop table Theatre_fix
drop table Theatre
drop table Theatre_Save

drop table Sport_fix
drop table Sport
drop table Sport_Save
