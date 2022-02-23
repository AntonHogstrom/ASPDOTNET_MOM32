using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EF_MOM_3_2.Migrations
{
    public partial class AlbumChange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "CD",
                newName: "Album");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Album",
                table: "CD",
                newName: "Name");
        }
    }
}
