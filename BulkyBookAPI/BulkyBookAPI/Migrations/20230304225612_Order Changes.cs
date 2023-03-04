using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BulkyBookAPI.Migrations
{
    public partial class OrderChanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderedBook_Book_BookId",
                table: "OrderedBook");

            migrationBuilder.DropIndex(
                name: "IX_OrderedBook_BookId",
                table: "OrderedBook");

            migrationBuilder.DropColumn(
                name: "BookQuantity",
                table: "OrderedBook");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BookQuantity",
                table: "OrderedBook",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_OrderedBook_BookId",
                table: "OrderedBook",
                column: "BookId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderedBook_Book_BookId",
                table: "OrderedBook",
                column: "BookId",
                principalTable: "Book",
                principalColumn: "BookId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
