using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PizzaModelsLibrary;

namespace PizzaDALEFLibrary
{
    class PizzaContext : DbContext
    {

        public PizzaContext():base(ConfigurationManager.ConnectionStrings["conn"].ConnectionString)
        {
            //Database.SetInitializer(new DropCreateDatabaseAlways<PizzaContext>());

        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CartPizzas>().HasKey(cp => new { cp.PizzaId, cp.CartNumber });
            //modelBuilder.Entity<GoldCustomer>().Map
        }
        public DbSet<Pizza> Pizzas { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<CartPizzas> CartPizzas { get; set; }

    }
}
