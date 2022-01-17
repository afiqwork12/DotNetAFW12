create database dbQuestion17012022
use dbQuestion17012022

create table ITEM 
(
itemname varchar(50) primary key,
itemtype varchar(1),
itemcolor varchar(20)
)

create table EMP
(
empno int identity(1,1) primary key,
empname varchar(50),
salary int,
--deptname varchar(30) null references DEPARTMENT(deptname),
bossno int null references EMP(empno)
)

create table DEPARTMENT
(
deptname varchar(50) primary key,
deptfloor int,
deptphone int, 
mgrid int not null references EMP(empno)
)

alter table EMP
add deptname varchar(50) null references DEPARTMENT(deptname)

create table SALES
(
salesno int identity(101,1) primary key,
saleqty int,
itemname varchar(50) not null references ITEM(itemname),
deptname varchar(50) not null references DEPARTMENT(deptname)
)