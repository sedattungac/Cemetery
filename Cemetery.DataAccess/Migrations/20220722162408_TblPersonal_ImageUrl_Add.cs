using Microsoft.EntityFrameworkCore.Migrations;

namespace Cemetery.DataAccess.Migrations
{
    public partial class TblPersonal_ImageUrl_Add : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Personals",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Personals");
        }
    }
}
