using Microsoft.EntityFrameworkCore.Migrations;

namespace CustomersAPI.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Age = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "Age", "Name" },
                values: new object[] { 101, 23, "Tim" });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "Age", "Name" },
                values: new object[] { 102, 33, "Jim" });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "Age", "Name" },
                values: new object[] { 103, 29, "Lim" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Customers");
        }
    }
}
