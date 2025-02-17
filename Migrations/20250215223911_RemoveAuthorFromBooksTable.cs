using Microsoft.EntityFrameworkCore.Migrations;

namespace my_books.Migrations
{
    public partial class RemoveAuthorFromBooksTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Author",
                table: "books");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Author",
                table: "books",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
