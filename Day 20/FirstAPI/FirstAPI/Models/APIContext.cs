using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace FirstAPI.Models
{
    public class APIContext : DbContext
    {
        public APIContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Employee> Employees { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>().HasData(
                new Employee()
                {
                    Id = 1,
                    Name = "Tim",
                    Age = 23
                },
                new Employee()
                {
                    Id = 2,
                    Name = "Jim",
                    Age = 33
                },
                new Employee()
                {
                    Id = 3,
                    Name = "Lim",
                    Age = 29
                }
            );
            base.OnModelCreating(modelBuilder);
        }

    }
}
