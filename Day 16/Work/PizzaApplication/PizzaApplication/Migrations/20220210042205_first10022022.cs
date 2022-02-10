using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PizzaApplication.Migrations
{
    public partial class first10022022 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Phone = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Age = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Phone);
                });

            migrationBuilder.CreateTable(
                name: "Pizzas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    IsVeg = table.Column<bool>(nullable: false),
                    Price = table.Column<double>(nullable: false),
                    Pic = table.Column<string>(nullable: true),
                    Details = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pizzas", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Phone", "Age", "Name" },
                values: new object[] { "+6596859685", 23, "John" });

            migrationBuilder.InsertData(
                table: "Pizzas",
                columns: new[] { "Id", "Details", "IsVeg", "Name", "Pic", "Price" },
                values: new object[] { 101, "Pepe", true, "ABC", "/images/__opt__aboutcom__coeus__resources__content_migration__simply_recipes__uploads__2019__09__easy-pepperoni-pizza-lead-3-8f256746d649404baa36a44d271329bc.jpg", 12.4 });

            migrationBuilder.InsertData(
                table: "Pizzas",
                columns: new[] { "Id", "Details", "IsVeg", "Name", "Pic", "Price" },
                values: new object[] { 102, "pizzzzzzzzzza", false, "BBB", "/images/53110049.gif", 45.7 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Pizzas");
        }
    }
}
