using Microsoft.EntityFrameworkCore.Migrations;

namespace NotificationPro.Migrations
{
    public partial class link_delete_ispublic : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Ispublic",
                table: "Links");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Ispublic",
                table: "Links",
                nullable: false,
                defaultValue: false);
        }
    }
}
