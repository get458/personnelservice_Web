using Microsoft.EntityFrameworkCore.Migrations;

namespace Personnel_Service.Migrations
{
    public partial class m15 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Worker");

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "Worker",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "Worker",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Nationality",
                table: "Worker",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "Worker");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "Worker");

            migrationBuilder.DropColumn(
                name: "Nationality",
                table: "Worker");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Worker",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
