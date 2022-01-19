-- stored procedures, triggers, cursors,
use Northwind

begin
	declare
	@score int,
	@dob datetime,
	@name varchar(20)
	set @dob = '1997-6-6'
	set @score = 100
	set @name = 'Afiq'
	set @score = @score - 20
	print 'Hello ' + @name
	print @score
	if(@score > 70)
		print 'Pass'
	else
		print 'Fail'
	print 'My date of birth is ' + CAST(@dob as varchar(20))
end

begin
	declare
	@count int = 0
	while(@count < 10)
		begin
			print @count
			set @count += 1
		end
end

create proc proc_First_Procudure
as
begin
	declare
	@count int = 0
	while(@count < 10)
		begin
			print @count
			set @count += 1
		end
end

exec proc_First_Procudure

create proc proc_PrintResult(@score int)
as
begin
	if(@score > 70)
		print 'Pass'
	else
		print 'Fail'
end

alter proc proc_PrintResult(@score int, @name varchar(20))
as
begin
	print 'Hello ' + @name
	if(@score > 70)
		print 'Pass'
	else
		print 'Fail'
end

exec proc_PrintResult 60, 'Afiq'

exec proc_PrintResult 80, 'Afiq'

create proc proc_calculate(@amount float, @tax float out)
as
begin
	print 'Calculating......'
	set @tax = @amount * 10.2/100
	print 'Done'
end

declare @giventax float
exec proc_calculate 10000, @giventax out
print @giventax

select * from [Order Details]

alter proc proc_PrintPayable(@OrderNumber varchar(10))
as
begin
	declare
	@CustName varchar(20),
	@Gross float,
	@Discount float,
	@Fright float,
	@NetPrice float
	set @CustName = (select ContactName from Customers where CustomerID = 
						(
							select CustomerID from Orders where OrderID = @OrderNumber
						)
					)
	print 'Hello ' + @CustName
	set @Gross =	(
						select SUM(UnitPrice * Quantity) from [Order Details] where OrderID = @OrderNumber
					)
	set @Discount = (
						select SUM(Discount) from [Order Details] where OrderID = @OrderNumber
					)
	if(@Discount > 0)
		set @Gross = @Gross - (@Gross * (@Discount / 100))
	set @Fright = (select Freight from Orders where OrderID = @OrderNumber)
	set @NetPrice = @Gross + @Fright
	print 'Gross Amount ' + CAST(@Gross as varchar(20))
	print 'Freight Amount ' + CAST(@Fright as varchar(20))
	print '---------------------------------'
	print 'Net Amount ' + CAST(@NetPrice as varchar(20))
end

sp_help orders

exec proc_PrintPayable '10348' -- select top(10) OrderID from [Order Details]

begin
	declare @OrderNumbers CURSOR 
	set @OrderNumbers = CURSOR FOR select top(10) OrderID from [Order Details]

end

select * from Orders where OrderID = '10348'

create proc proc_FetchAllCustomers
as
  select * from Customers

exec proc_FetchAllCustomers

create table tblSimple
(f1 int primary key,
f2 varchar(20))

create proc proc_InsertIntoSimple(@f1 int,@f2 varchar(20))
as
  insert into tblSimple values(@f1,@f2)

exec proc_InsertIntoSimple 101,'Hello'


select * from tblSimple
select * from tblStatus

delete from tblSimple
delete from tblStatus



--transactions
create table tblStatus
(
	f1 int,
	msg varchar(20)
)
begin tran
	declare @input int = 104
	insert into tblSimple values(@input, 'Check Done')
	insert into tblStatus values(@input, 'Success')
	if((select count(f1) from tblSimple where f1 = @input) > 0)
		commit
	else
		rollback


create proc proc_Transaction(@f1 int,@f2 varchar(20))
as
begin
	begin tran
	declare @count int = (select count(f1) from tblSimple where f1 = @f1)
	insert into tblSimple values(@f1, @f2)
	insert into tblStatus values(@f1, 'Success')
	if(@count > 0)
		rollback
	else
		commit
end

exec proc_Transaction 103, 'new hello'
exec proc_Transaction 104, 'new hello'
exec proc_Transaction 105, 'new hello'
exec proc_Transaction 107, 'new hello'

select * from tblSimple
select * from tblStatus

--create a stored procedure that will calculate total salary
--take input of basic, dearness allowance, house rent allowance, deductions and number of leaves
--if the number of leaves is more than 2 deduct the pay for the extra days and calculate the net salary

create proc proc_CalculateTotalSalary(@basic float, @da float,@hra float, @deductions float, @nol int)
as 
begin
	declare
	@NettSalary float,
	@GrossSalary float = @basic + @da + @hra - @deductions
	if(@nol > 2)
		begin
			declare
			@PerDaySalary float = @GrossSalary / 30
			set @NettSalary = @GrossSalary - ((@nol - 2) * @PerDaySalary)
			print 'Leave Deductions ' + CAST(((@nol - 2) * @PerDaySalary) as varchar(20))
			print '-------------------------------------------------'
		end
	else
		set @NettSalary = @GrossSalary
	print 'Gross Salary ' + CAST(@GrossSalary as varchar(20))
	print '-------------------------------------------------'
	print 'Nett Salary ' + CAST(@NettSalary as varchar(20))
end

exec proc_CalculateTotalSalary 10000, 5000, 3000, 1500, 2
exec proc_CalculateTotalSalary 10000, 5000, 3000, 1500, 3

select * from tblSimple
select * from tblStatus

alter function fn_Sample(@num int)
returns int
as 
begin
	set @num += 100
	return @num
end

select dbo.fn_Sample(UnitPrice) 'Sample' from Products


create function fn_CalculateTotalSalary(@basic float, @da float,@hra float, @deductions float, @nol int)
returns float
as 
begin
	declare
	@NettSalary float,
	@GrossSalary float = @basic + @da + @hra - @deductions
	if(@nol > 2)
		begin
			declare
			@PerDaySalary float = @GrossSalary / 30
			set @NettSalary = @GrossSalary - ((@nol - 2) * @PerDaySalary)
		end
	else
		set @NettSalary = @GrossSalary
	return @NettSalary
end

select dbo.fn_CalculateTotalSalary(10000, 5000, 3000, 1500, 3) 'Nett Salary'

create function fn_CalculateTotalSalaryTable(@basic float, @da float,@hra float, @deductions float, @nol int)
returns @SalTable Table
(
	GrossAmount float,
	LeaveDeductions float,
	NettAmount float
)
as 
begin
	declare
	@NettSalary float,
	@GrossSalary float = @basic + @da + @hra - @deductions
	if(@nol > 2)
		begin
			declare
			@PerDaySalary float = @GrossSalary / 30
			set @NettSalary = @GrossSalary - ((@nol - 2) * @PerDaySalary)
			insert into @SalTable values(@GrossSalary, ((@nol - 2) * @PerDaySalary), @NettSalary)
		end
	else
		begin
			set @NettSalary = @GrossSalary
			insert into @SalTable values(@GrossSalary, 0, @NettSalary)
		end
	return 
end

select * from dbo.fn_CalculateTotalSalaryTable(10000, 5000, 3000, 1500, 3)

select * from tblSimple
select * from tblStatus

--triggers

create proc proc_Transaction1(@f1 int,@f2 varchar(20))
as
begin
	begin tran
	declare @count int = (select count(f1) from tblSimple where f1 = @f1)
	insert into tblSimple values(@f1, @f2)
	if(@count > 0)
		rollback
	else
		commit
end

create trigger trg_InsertCheck
on tblSimple
for Insert
as
begin
	print 'hello'

end

drop trigger trg_InsertCheck

update tblSimple set f2 = 'asdasa' where f1 = 101

create table account
(
	accno int primary key,
	balance float
)

create table trans
(
	tranno int primary key,
	fromacc int references account(accno),
	toacc int references account(accno),
	amount float,
	status varchar(100)
)

insert into account values(101,5000)
insert into account values(102,1000)
insert into account values(103,10000)

select * from account

alter trigger trg_Transact
on trans
for Insert
as
begin
	declare @bal float, @check float, @credit float
	set @bal = 
	(
		select balance from account where accno = 
		(
			select fromacc from inserted
		)
	)
	set @check = @bal - (select amount from inserted)
	set @credit = (select fromacc from inserted)
	if(@check < @bal)
		update trans set status = 'Failed' where tranno = (select tranno from inserted)
	else
		begin
			update account set balance = @check where accno = (select fromacc from inserted)
			update account set balance = balance + @credit where accno = (select toacc from inserted)
			update trans set status = 'Success' where tranno = (select tranno from inserted)
		end
end

drop trigger trg_Transact

update account set balance = 1000 where accno = 101

insert into trans values (8,101,102,500,null)
select * from account
select * from trans



--cursors

declare
@accountNo int,
@balance float
declare cur_account cursor for select * from account

open cur_account 

fetch next from cur_account into @accountNo, @balance

while(@@FETCH_STATUs = 0)
begin
	print'Account Number ' + CAST(@accountNo as varchar(20))
	print'Balance ' + CAST(@balance as varchar(20))
	print'-----------------------------------------------------'
	
		
		declare @amount float, @status varchar(100)
		declare cur_tran cursor for select amount, status from trans where fromacc = @accountNo
		open cur_tran
		fetch next from cur_tran into @amount,@status
		while(@@FETCH_STATUS = 0)
		begin
			print'                   Amount Transferred ' + CAST(@amount as varchar(100))
			print'                   Status ' + @status
			print'-----------------------------------------------------'
			fetch next from cur_tran into @amount,@status
		end

		close cur_tran
		DEALLOCATE cur_tran

		fetch next from cur_account into @accountNo, @balance
end

close cur_account

DEALLOCATE cur_account

--declare 
--@account int,
--@Balance float

--DECLARE cur_account CURSOR FOR select * from account

--OPEN cur_account

--FETCH NEXT FROM cur_account INTO @account,@balance

--while(@@FETCH_STATUS =0)
--begin
--   print 'Account number : '+ cast(@account as varchar(20))
--   print 'Account Balance : '+ cast(@Balance as varchar(20))
--   print '-----------------------------------'
  
--	   declare @amount float, @status varchar(20)
--	   DECLARE cur_tran CURSOR FOR select amount,status from trans where fromacc = @account

--	   OPEN cur_tran

--	   FETCH NEXT FROM cur_tran INTO @amount,@status
	    
--	   while(@@FETCH_STATUS =0)
--	   begin
--		   print '               Amount transffered : '+ cast(@amount as varchar(20))
--		   print '               Transaction status : '+ @status
--		   print '-----------------------------------'
--		   FETCH NEXT FROM cur_tran INTO @amount,@status
--	   end 

--	   CLOSE cur_tran
--	   DEALLOCATE cur_tran
--   FETCH NEXT FROM cur_account INTO @account,@balance
--end

--CLOSE cur_account
--DEALLOCATE cur_account

--declare <vars for the cursor and the cursor itself>
--e.g.
--declare 
--@account int,
--@Balance float
--DECLARE cur_account CURSOR FOR select * from account

--open
--e.g.
--OPEN cur_account

--fetch
--e.g.
--FETCH NEXT FROM cur_account INTO @account,@balance

--while
--e.g.
--while(@@FETCH_STATUS =0)
--begin
	--FETCH NEXT FROM cur_account INTO @account,@balance
--end

--begin
	--content
	--declare
	--open
	--fetch
	--while
	--begin
	--content
	--fetch
	--end
	--close
	--deallocate
--fetch
--end
--close
--deallocate