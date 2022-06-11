using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class img6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "WritetPassword",
                table: "Writers",
                newName: "WriterPassword");

            migrationBuilder.RenameColumn(
                name: "WritetImage",
                table: "Writers",
                newName: "WriterMail");

            migrationBuilder.RenameColumn(
                name: "WriterMial",
                table: "Writers",
                newName: "WriterImage");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "WriterPassword",
                table: "Writers",
                newName: "WritetPassword");

            migrationBuilder.RenameColumn(
                name: "WriterMail",
                table: "Writers",
                newName: "WritetImage");

            migrationBuilder.RenameColumn(
                name: "WriterImage",
                table: "Writers",
                newName: "WriterMial");
        }
    }
}
