using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.Entity;

namespace QuestionForDay12Application
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext() : base(ConfigurationManager.ConnectionStrings["conn"].ConnectionString)
        {

        }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }
        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    base.OnModelCreating(modelBuilder);
        //}
    }
}
