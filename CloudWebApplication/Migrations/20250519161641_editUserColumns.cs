using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CloudWebApplication.Migrations
{
    /// <inheritdoc />
    public partial class editUserColumns : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CustomerName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "age",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CustomerName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "age",
                table: "AspNetUsers");
        }
    }
}
