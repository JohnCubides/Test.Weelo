using Microsoft.EntityFrameworkCore.Migrations;

namespace Test.Weelo.Persistence.Migrations.Application
{
    public partial class UpdatepropertyImageTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "File",
                table: "PropertyImage",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "File",
                table: "PropertyImage");
        }
    }
}
