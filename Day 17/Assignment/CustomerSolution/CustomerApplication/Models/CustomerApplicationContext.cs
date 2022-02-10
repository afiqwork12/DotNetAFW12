using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerApplication.Models
{
    public class CustomerApplicationContext : DbContext
    {
        public CustomerApplicationContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Customer> Customers { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>().HasData(
                new Customer()
                {
                    Id = 1,
                    Phone = "+6596859685",
                    Name = "John",
                    Age = 23
                }
            );
            base.OnModelCreating(modelBuilder);
        }
    }
}
