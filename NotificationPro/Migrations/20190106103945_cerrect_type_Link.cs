using Microsoft.EntityFrameworkCore.Migrations;

namespace NotificationPro.Migrations
{
    public partial class cerrect_type_Link : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Act",
                table: "Links");

            migrationBuilder.RenameColumn(
                name: "Status",
                table: "Links",
                newName: "Type");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Type",
                table: "Links",
                newName: "Status");

            migrationBuilder.AddColumn<string>(
                name: "Act",
                table: "Links",
                nullable: true);
        }
    }
}
