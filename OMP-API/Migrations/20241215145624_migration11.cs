using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OMP_API.Migrations
{
    /// <inheritdoc />
    public partial class migration11 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CustomerModules_Customers_CustomerId1",
                table: "CustomerModules");

            migrationBuilder.DropIndex(
                name: "IX_CustomerModules_CustomerId1",
                table: "CustomerModules");

            migrationBuilder.DropColumn(
                name: "CustomerId1",
                table: "CustomerModules");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CustomerId1",
                table: "CustomerModules",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_CustomerModules_CustomerId1",
                table: "CustomerModules",
                column: "CustomerId1");

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerModules_Customers_CustomerId1",
                table: "CustomerModules",
                column: "CustomerId1",
                principalTable: "Customers",
                principalColumn: "id");
        }
    }
}
