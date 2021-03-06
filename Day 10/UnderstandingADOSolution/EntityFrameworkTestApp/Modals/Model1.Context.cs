//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace EntityFrameworkTestApp.Modals
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class NorthwindEntities : DbContext
    {
        public NorthwindEntities()
            : base("name=NorthwindEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<account> accounts { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<CustomerDemographic> CustomerDemographics { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Order_Detail> Order_Details { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Region> Regions { get; set; }
        public virtual DbSet<Shipper> Shippers { get; set; }
        public virtual DbSet<Supplier> Suppliers { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<tblSimple> tblSimples { get; set; }
        public virtual DbSet<Territory> Territories { get; set; }
        public virtual DbSet<tran> trans { get; set; }
        public virtual DbSet<Alphabetical_list_of_product> Alphabetical_list_of_products { get; set; }
        public virtual DbSet<Category_Sales_for_1997> Category_Sales_for_1997 { get; set; }
        public virtual DbSet<Current_Product_List> Current_Product_Lists { get; set; }
        public virtual DbSet<Customer_and_Suppliers_by_City> Customer_and_Suppliers_by_Cities { get; set; }
        public virtual DbSet<Invoice> Invoices { get; set; }
        public virtual DbSet<Order_Details_Extended> Order_Details_Extendeds { get; set; }
        public virtual DbSet<Order_Subtotal> Order_Subtotals { get; set; }
        public virtual DbSet<Orders_Qry> Orders_Qries { get; set; }
        public virtual DbSet<Product_Sales_for_1997> Product_Sales_for_1997 { get; set; }
        public virtual DbSet<Products_Above_Average_Price> Products_Above_Average_Prices { get; set; }
        public virtual DbSet<Products_by_Category> Products_by_Categories { get; set; }
        public virtual DbSet<Sales_by_Category> Sales_by_Categories { get; set; }
        public virtual DbSet<Sales_Totals_by_Amount> Sales_Totals_by_Amounts { get; set; }
        public virtual DbSet<Summary_of_Sales_by_Quarter> Summary_of_Sales_by_Quarters { get; set; }
        public virtual DbSet<Summary_of_Sales_by_Year> Summary_of_Sales_by_Years { get; set; }
    
        [DbFunction("NorthwindEntities", "fn_CalculateTotalSalaryTable")]
        public virtual IQueryable<fn_CalculateTotalSalaryTable_Result> fn_CalculateTotalSalaryTable(Nullable<double> basic, Nullable<double> da, Nullable<double> hra, Nullable<double> deductions, Nullable<int> nol)
        {
            var basicParameter = basic.HasValue ?
                new ObjectParameter("basic", basic) :
                new ObjectParameter("basic", typeof(double));
    
            var daParameter = da.HasValue ?
                new ObjectParameter("da", da) :
                new ObjectParameter("da", typeof(double));
    
            var hraParameter = hra.HasValue ?
                new ObjectParameter("hra", hra) :
                new ObjectParameter("hra", typeof(double));
    
            var deductionsParameter = deductions.HasValue ?
                new ObjectParameter("deductions", deductions) :
                new ObjectParameter("deductions", typeof(double));
    
            var nolParameter = nol.HasValue ?
                new ObjectParameter("nol", nol) :
                new ObjectParameter("nol", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.CreateQuery<fn_CalculateTotalSalaryTable_Result>("[NorthwindEntities].[fn_CalculateTotalSalaryTable](@basic, @da, @hra, @deductions, @nol)", basicParameter, daParameter, hraParameter, deductionsParameter, nolParameter);
        }
    
        public virtual ObjectResult<CustOrderHist_Result> CustOrderHist(string customerID)
        {
            var customerIDParameter = customerID != null ?
                new ObjectParameter("CustomerID", customerID) :
                new ObjectParameter("CustomerID", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<CustOrderHist_Result>("CustOrderHist", customerIDParameter);
        }
    
        public virtual ObjectResult<CustOrdersDetail_Result> CustOrdersDetail(Nullable<int> orderID)
        {
            var orderIDParameter = orderID.HasValue ?
                new ObjectParameter("OrderID", orderID) :
                new ObjectParameter("OrderID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<CustOrdersDetail_Result>("CustOrdersDetail", orderIDParameter);
        }
    
        public virtual ObjectResult<CustOrdersOrders_Result> CustOrdersOrders(string customerID)
        {
            var customerIDParameter = customerID != null ?
                new ObjectParameter("CustomerID", customerID) :
                new ObjectParameter("CustomerID", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<CustOrdersOrders_Result>("CustOrdersOrders", customerIDParameter);
        }
    
        public virtual ObjectResult<Employee_Sales_by_Country_Result> Employee_Sales_by_Country(Nullable<System.DateTime> beginning_Date, Nullable<System.DateTime> ending_Date)
        {
            var beginning_DateParameter = beginning_Date.HasValue ?
                new ObjectParameter("Beginning_Date", beginning_Date) :
                new ObjectParameter("Beginning_Date", typeof(System.DateTime));
    
            var ending_DateParameter = ending_Date.HasValue ?
                new ObjectParameter("Ending_Date", ending_Date) :
                new ObjectParameter("Ending_Date", typeof(System.DateTime));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Employee_Sales_by_Country_Result>("Employee_Sales_by_Country", beginning_DateParameter, ending_DateParameter);
        }
    
        public virtual int proc_calculate(Nullable<double> amount, ObjectParameter tax)
        {
            var amountParameter = amount.HasValue ?
                new ObjectParameter("amount", amount) :
                new ObjectParameter("amount", typeof(double));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("proc_calculate", amountParameter, tax);
        }
    
        public virtual int proc_CalculateTotalSalary(Nullable<double> basic, Nullable<double> da, Nullable<double> hra, Nullable<double> deductions, Nullable<int> nol)
        {
            var basicParameter = basic.HasValue ?
                new ObjectParameter("basic", basic) :
                new ObjectParameter("basic", typeof(double));
    
            var daParameter = da.HasValue ?
                new ObjectParameter("da", da) :
                new ObjectParameter("da", typeof(double));
    
            var hraParameter = hra.HasValue ?
                new ObjectParameter("hra", hra) :
                new ObjectParameter("hra", typeof(double));
    
            var deductionsParameter = deductions.HasValue ?
                new ObjectParameter("deductions", deductions) :
                new ObjectParameter("deductions", typeof(double));
    
            var nolParameter = nol.HasValue ?
                new ObjectParameter("nol", nol) :
                new ObjectParameter("nol", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("proc_CalculateTotalSalary", basicParameter, daParameter, hraParameter, deductionsParameter, nolParameter);
        }
    
        public virtual ObjectResult<proc_FetchAllCustomers_Result> proc_FetchAllCustomers()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<proc_FetchAllCustomers_Result>("proc_FetchAllCustomers");
        }
    
        public virtual int proc_First_Procudure()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("proc_First_Procudure");
        }
    
        public virtual int proc_InsertIntoSimple(Nullable<int> f1, string f2)
        {
            var f1Parameter = f1.HasValue ?
                new ObjectParameter("f1", f1) :
                new ObjectParameter("f1", typeof(int));
    
            var f2Parameter = f2 != null ?
                new ObjectParameter("f2", f2) :
                new ObjectParameter("f2", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("proc_InsertIntoSimple", f1Parameter, f2Parameter);
        }
    
        public virtual int proc_PrintPayable(string orderNumber)
        {
            var orderNumberParameter = orderNumber != null ?
                new ObjectParameter("OrderNumber", orderNumber) :
                new ObjectParameter("OrderNumber", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("proc_PrintPayable", orderNumberParameter);
        }
    
        public virtual int proc_PrintResult(Nullable<int> score, string name)
        {
            var scoreParameter = score.HasValue ?
                new ObjectParameter("score", score) :
                new ObjectParameter("score", typeof(int));
    
            var nameParameter = name != null ?
                new ObjectParameter("name", name) :
                new ObjectParameter("name", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("proc_PrintResult", scoreParameter, nameParameter);
        }
    
        public virtual int proc_Transaction(Nullable<int> f1, string f2)
        {
            var f1Parameter = f1.HasValue ?
                new ObjectParameter("f1", f1) :
                new ObjectParameter("f1", typeof(int));
    
            var f2Parameter = f2 != null ?
                new ObjectParameter("f2", f2) :
                new ObjectParameter("f2", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("proc_Transaction", f1Parameter, f2Parameter);
        }
    
        public virtual ObjectResult<Sales_by_Year_Result> Sales_by_Year(Nullable<System.DateTime> beginning_Date, Nullable<System.DateTime> ending_Date)
        {
            var beginning_DateParameter = beginning_Date.HasValue ?
                new ObjectParameter("Beginning_Date", beginning_Date) :
                new ObjectParameter("Beginning_Date", typeof(System.DateTime));
    
            var ending_DateParameter = ending_Date.HasValue ?
                new ObjectParameter("Ending_Date", ending_Date) :
                new ObjectParameter("Ending_Date", typeof(System.DateTime));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Sales_by_Year_Result>("Sales_by_Year", beginning_DateParameter, ending_DateParameter);
        }
    
        public virtual ObjectResult<SalesByCategory_Result> SalesByCategory(string categoryName, string ordYear)
        {
            var categoryNameParameter = categoryName != null ?
                new ObjectParameter("CategoryName", categoryName) :
                new ObjectParameter("CategoryName", typeof(string));
    
            var ordYearParameter = ordYear != null ?
                new ObjectParameter("OrdYear", ordYear) :
                new ObjectParameter("OrdYear", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<SalesByCategory_Result>("SalesByCategory", categoryNameParameter, ordYearParameter);
        }
    
        public virtual int sp_alterdiagram(string diagramname, Nullable<int> owner_id, Nullable<int> version, byte[] definition)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            var versionParameter = version.HasValue ?
                new ObjectParameter("version", version) :
                new ObjectParameter("version", typeof(int));
    
            var definitionParameter = definition != null ?
                new ObjectParameter("definition", definition) :
                new ObjectParameter("definition", typeof(byte[]));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_alterdiagram", diagramnameParameter, owner_idParameter, versionParameter, definitionParameter);
        }
    
        public virtual int sp_creatediagram(string diagramname, Nullable<int> owner_id, Nullable<int> version, byte[] definition)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            var versionParameter = version.HasValue ?
                new ObjectParameter("version", version) :
                new ObjectParameter("version", typeof(int));
    
            var definitionParameter = definition != null ?
                new ObjectParameter("definition", definition) :
                new ObjectParameter("definition", typeof(byte[]));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_creatediagram", diagramnameParameter, owner_idParameter, versionParameter, definitionParameter);
        }
    
        public virtual int sp_dropdiagram(string diagramname, Nullable<int> owner_id)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_dropdiagram", diagramnameParameter, owner_idParameter);
        }
    
        public virtual ObjectResult<sp_helpdiagramdefinition_Result> sp_helpdiagramdefinition(string diagramname, Nullable<int> owner_id)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_helpdiagramdefinition_Result>("sp_helpdiagramdefinition", diagramnameParameter, owner_idParameter);
        }
    
        public virtual ObjectResult<sp_helpdiagrams_Result> sp_helpdiagrams(string diagramname, Nullable<int> owner_id)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_helpdiagrams_Result>("sp_helpdiagrams", diagramnameParameter, owner_idParameter);
        }
    
        public virtual int sp_renamediagram(string diagramname, Nullable<int> owner_id, string new_diagramname)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            var new_diagramnameParameter = new_diagramname != null ?
                new ObjectParameter("new_diagramname", new_diagramname) :
                new ObjectParameter("new_diagramname", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_renamediagram", diagramnameParameter, owner_idParameter, new_diagramnameParameter);
        }
    
        public virtual int sp_upgraddiagrams()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_upgraddiagrams");
        }
    
        public virtual ObjectResult<Ten_Most_Expensive_Products_Result> Ten_Most_Expensive_Products()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Ten_Most_Expensive_Products_Result>("Ten_Most_Expensive_Products");
        }
    }
}
