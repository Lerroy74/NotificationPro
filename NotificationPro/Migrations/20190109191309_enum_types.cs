using Microsoft.EntityFrameworkCore.Migrations;

namespace NotificationPro.Migrations
{
    public partial class enum_types : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Type",
                table: "Links",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Type",
                table: "Links",
                nullable: true,
                oldClrType: typeof(int));
        }
    }
}
