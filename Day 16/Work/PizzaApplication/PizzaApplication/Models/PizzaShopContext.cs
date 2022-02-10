using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaApplication.Models
{
    public class PizzaShopContext : DbContext
    {
        public PizzaShopContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Pizza> Pizzas { get; set; }
        public DbSet<Customer> Customers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Pizza>().HasData(
                new Pizza()
                {
                    Id = 101,
                    Name = "ABC",
                    IsVeg = true,
                    Price = 12.4,
                    Pic = "/images/__opt__aboutcom__coeus__resources__content_migration__simply_recipes__uploads__2019__09__easy-pepperoni-pizza-lead-3-8f256746d649404baa36a44d271329bc.jpg",
                    Details = "Pepe"
                },
                new Pizza()
                {
                    Id = 102,
                    Name = "BBB",
                    IsVeg = false,
                    Price = 45.7,
                    Pic = "/images/53110049.gif",
                    Details = "pizzzzzzzzzza"
                }
            );
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
        