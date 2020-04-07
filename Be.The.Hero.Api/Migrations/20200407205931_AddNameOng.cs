using Microsoft.EntityFrameworkCore.Migrations;

namespace Be.The.Hero.Api.Migrations
{
    public partial class AddNameOng : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Ongs",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Ongs");
        }
    }
}
