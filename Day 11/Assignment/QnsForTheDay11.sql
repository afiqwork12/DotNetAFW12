create database QnsForTheDay11
create table tblEmployee
(
	ID int identity(1,1) primary key,
	Name varchar(30),
	Age int
)

create proc proc_InsertEmploye(@ename varchar(30), @eage int)
as
begin
	insert into tblEmployee(Name,Age) values(@ename,@eage)
end

exec proc_InsertEmploye 'John', 20
exec proc_InsertEmploye 'Mary', 21
exec proc_InsertEmploye 'Jones', 19
exec proc_InsertEmploye 'Sam', 24
exec proc_InsertEmploye 'Tom', 35
exec proc_InsertEmploye 'Smith', 30

create proc proc_GetAllEmployee
as
begin
	select * from tblEmployee
end

exec proc_GetAllEmployee

create proc proc_UpdateEmployeeAgeByID(@eid int, @eage int)
as
begin
	update tblEmployee set Age = @eage where ID = @eid
end

exec proc_UpdateEmployeeAgeByID 1, 21

create proc proc_GetEmployeeByID(@eid int)
as
begin
	select * from tblEmployee where ID = @eid
end

exec proc_GetEmployeeByID 1

create proc proc_DeleteEmployeeByID(@eid int)
as
begin
	delete from tblEmployee where ID = @eid
end

exec proc_DeleteEmployeeByID 1
