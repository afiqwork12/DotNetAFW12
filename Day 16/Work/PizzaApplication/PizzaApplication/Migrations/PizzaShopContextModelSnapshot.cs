﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PizzaApplication.Models;

namespace PizzaApplication.Migrations
{
    [DbContext(typeof(PizzaShopContext))]
    partial class PizzaShopContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.14-servicing-32113")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("PizzaApplication.Models.Customer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Age");

                    b.Property<string>("Name");

                    b.Property<string>("Phone");

                    b.HasKey("Id");

                    b.ToTable("Customers");

                    b.HasData(
                        new { Id = 1, Age = 23, Name = "John", Phone = "+6596859685" }
                    );
                });

            modelBuilder.Entity("PizzaApplication.Models.Pizza", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Details");

                    b.Property<bool>("IsVeg");

                    b.Property<string>("Name");

                    b.Property<string>("Pic");

                    b.Property<double>("Price");

                    b.HasKey("Id");

                    b.ToTable("Pizzas");

                    b.HasData(
                        new { Id = 101, Details = "Pepe", IsVeg = true, Name = "ABC", Pic = "/images/__opt__aboutcom__coeus__resources__content_migration__simply_recipes__uploads__2019__09__easy-pepperoni-pizza-lead-3-8f256746d649404baa36a44d271329bc.jpg", Price = 12.4 },
                        new { Id = 102, Details = "pizzzzzzzzzza", IsVeg = false, Name = "BBB", Pic = "/images/53110049.gif", Price = 45.7 }
                    );
                });
#pragma warning restore 612, 618
        }
    }
}
