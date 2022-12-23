using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SorteioRetornar.Migrations
{
    public partial class FixMappings : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Client_GeneratedNumber",
                table: "Client");

            migrationBuilder.DropColumn(
                name: "GeneratedNumber",
                table: "Client");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "GeneratedNumber",
                table: "Client",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Client_GeneratedNumber",
                table: "Client",
                column: "GeneratedNumber",
                unique: true);
        }
    }
}
