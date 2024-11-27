using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OMP_API.Migrations
{
    /// <inheritdoc />
    public partial class initIndentity4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "identityUserId",
                table: "Users",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Users_identityUserId",
                table: "Users",
                column: "identityUserId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK__Users__IdentityUser",
                table: "Users",
                column: "identityUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK__Users__IdentityUser",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_identityUserId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "identityUserId",
                table: "Users");
        }
    }
}
