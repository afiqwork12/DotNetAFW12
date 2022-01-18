use Northwind

select * from Categories
select * from Products
select ProductName from Products
select ProductName, QuantityPerUnit from Products
select ProductName 'Product Name', QuantityPerUnit 'Quantity In Every Unit' from Products

select * from Employees

select * from Products where UnitPrice >= 15

select * from Products where UnitPrice > 15 and UnitPrice < 25

select * from Products where UnitPrice between 15 and 25

select * from Products where UnitPrice >= 15 and SupplierID = 17

--select the products that are supplied by 15 or the unitsinstock is less than 5

select * from Products where SupplierID = 15 or UnitsInStock < 5

select * from Products where SupplierID > 5 and SupplierID < 10

select * from Products where SupplierID in(8,12,13,18)

select * from Products where SupplierID not in(8,12,13,18)

select * from Products where ProductName = 'Ikura'

select * from Products where ProductName like '%on%'
select * from Products where ProductName like '_on%'
select * from Products where ProductName like '%on'

select avg(unitsinstock) 'Average Value of Units in Stock' from Products

select avg(unitsinstock) 'Average Value of Units in Stock', ProductName from Products
-- ^ no sense no good

select * from Products

select avg(unitsinstock) 'Average Value of Units in Stock', sum(unitsinstock) 'Sum of Units in Stock' from Products

--print the average price of products that are supplied by supplied with id 2,6,9

select avg(UnitPrice) 'Average Unit Price for Products that are supplied by supplier with id 2, 6, 9' from Products where SupplierID in (2,6,9)

select count(SupplierID) from Products

select count(distinct SupplierID) from Products

select distinct SupplierID from Products

select * from Suppliers	

select ProductName, Suppliers.CompanyName, Categories.CategoryName, UnitPrice 
from 
Products 
inner join Suppliers on Suppliers.SupplierID = Products.SupplierID 
inner join Categories on Categories.CategoryID = Products.CategoryID 
order by UnitPrice desc

select * from Products order by SupplierID

select * from Products order by UnitPrice desc

select * from Products order by SupplierID desc, UnitsInStock desc

--print all the products sorted by supplierid where the product name should contain 'e'

select * from Products where ProductName like '%e%' order by SupplierID

-- like is not case sensitive

select SupplierID, count(productID) 'Number of Products'  
from Products 
group by SupplierID

select SupplierID, count(productID) 'Number of Products'  
from Products 
where UnitsInStock > 0
group by SupplierID
order by 2,1

select SupplierID, count(productID) 'Number of Products'
from Products 
where UnitsInStock > 0 --and count(productID) > 2
group by SupplierID
having count(productID) > 2
order by 2,1

select SupplierID, count(productID) 'Number of Products', sum(UnitPrice) 'Total Price'
from Products 
where UnitsInStock > 0 --and count(productID) > 2
group by SupplierID
having count(productID) > 2 and sum(UnitPrice) between 50 and 100
order by 2,1

select * from Invoices

-- print the average price of products sold by every salesperson
-- if the average is greater than 3
-- where the ship country is france and the customer name contains 'e'
-- sort result by salesperson

select SalesPerson, round(avg(UnitPrice),2) 'Average Price'
from Invoices
where ShipCountry = 'France' and CustomerName like '%e%'
group by SalesPerson
having avg(UnitPrice) > 3
order by SalesPerson

-- non co related sub query

select * from Suppliers 

select SupplierID 
from Suppliers 
where Country = 'Japan'

select * from Products where SupplierID in (4,6)

select * 
from Products 
where SupplierID in 
(
	select SupplierID 
	from Suppliers 
	where Country = 'Japan'
)

select * 
from Products 
where SupplierID in 
(
	select SupplierID 
	from Suppliers 
	where Country = 'Germany'
)

select * 
from Products 
where SupplierID = 
(
	select SupplierID 
	from Suppliers 
	where CompanyName = 'Exotic Liquids'
)

select * 
from Products 
where SupplierID = 
(
	select SupplierID 
	from Suppliers 
	where CompanyName = 'Aux joyeux ecclésiastiques'
)

select SupplierID, avg(UnitsInStock) 'Average Units in Stock'
from Products
where SupplierID in
(
	select SupplierID
	from Suppliers
	where Region != 'NULL'
)
group by SupplierID
having avg(UnitsInStock) > 3
order by 'Average Units in Stock'

select * from Products
select * from Categories

select *
from Products
where CategoryID in
(
	select CategoryID
	from Categories
	where CategoryName like '%pro%'
)
and UnitsInStock > 0
order by UnitPrice

select * from [Order Details]
select * from Products
select * from Orders

--inner, outer, cross join

select * from [Order Details]


select * from products where ProductID not in(
select distinct ProductID from [Order Details])

select ProductName, od.UnitPrice,Quantity,od.UnitPrice*Quantity 'Product Price'
from Products p join [Order Details] od
on p.ProductID = od.ProductID
order by ProductName

select c.CompanyName, p.ProductName, od.UnitPrice, Quantity, Discount, od.UnitPrice*Quantity 'Total Price Before Discount', (od.UnitPrice*Quantity)*(1-Discount) 'Total Price After Discount'
from [Order Details] od
join [Orders] o
on od.OrderID = o.OrderID
join Customers c
on o.CustomerID = c.CustomerID
join Products p
on od.ProductID = p.ProductID
order by c.CompanyName, p.ProductName, od.UnitPrice, Quantity, Discount, 'Total Price Before Discount', 'Total Price After Discount'


select OrderDate, c.ContactName
from Orders o
join Customers c
on o.CustomerID = c.CustomerID

select * from Products where ProductID not in
(
	select distinct ProductID from [Order Details]
)

select ContactName 'Customer Name', CustomerID 
from Customers 
where CustomerID not in
(
	select distinct CustomerID from Orders
)

select ContactName 'Customer Name', CustomerID 
from Customers 
where CustomerID in
(
	select distinct CustomerID from Orders
)

select c.ContactName 'Customer name', o.OrderDate 'Data'
from Customers c
left outer join orders o
on c.CustomerID = o.CustomerID
order by 1 --832 rows

select c.ContactName 'Customer name', o.OrderDate 'Data'
from Customers c
right outer join orders o
on c.CustomerID = o.CustomerID
order by 1 --830 rows

select c.ContactName 'Customer name', o.OrderDate 'Data'
from Customers c
full outer join orders o
on c.CustomerID = o.CustomerID
order by 1 --832 rows

select TerritoryDescription, RegionDescription 
from Territories
join Region
on Territories.RegionID = Region.RegionID
order by TerritoryDescription, RegionDescription

select * from Customers

select CONCAT(FirstName,' ',LastName) 'Employee Name', count(OrderID) 'Number of Orders'
from Employees e
join Orders o
on e.EmployeeID = o.EmployeeID
group by CONCAT(FirstName,' ',LastName)
having count(OrderID) > 50
order by 2

select * from [Order Details]
--print orderid, product name and customer name
select c.ContactName 'Customer Name', o.OrderId, p.ProductName, od.UnitPrice*od.Quantity 'Price'
from Customers c
join Orders o
on c.CustomerID = o.CustomerID
join [Order Details] od
on od.OrderID = o.OrderID
join Products p
on p.ProductID = od.ProductID
order by od.UnitPrice*od.Quantity

select c.ContactName 'Customer Name', o.OrderId, p.ProductName, od.UnitPrice*od.Quantity 'Price'
from Customers c
left outer join Orders o
on c.CustomerID = o.CustomerID
left outer join [Order Details] od
on od.OrderID = o.OrderID
left outer join Products p
on p.ProductID = od.ProductID
order by od.UnitPrice*od.Quantity

select c.ContactName 'Customer Name', o.OrderId, p.ProductName, od.UnitPrice*od.Quantity 'Price'
from Products p
join [Order Details] od
on p.ProductID = od.ProductID 
join Orders o
on od.OrderID = o.OrderID
right outer join Customers c
on c.CustomerID = o.CustomerID
order by od.UnitPrice*od.Quantity

--cartesian product / joins tables regardless if related
select * from Region cross join Shippers

select * from Employees

-- self join = join to the same table
select emp.EmployeeID, CONCAT(emp.Title, ' - ', emp.FirstName,' ', emp.LastName) 'Employee Name', CONCAT(mgr.Title, ' - ', mgr.FirstName,' ', mgr.LastName) 'Reports To'
from Employees emp
left outer join Employees mgr
on mgr.EmployeeID = emp.ReportsTo

