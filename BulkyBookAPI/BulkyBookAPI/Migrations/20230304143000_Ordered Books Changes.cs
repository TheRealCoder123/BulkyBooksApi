using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BulkyBookAPI.Migrations
{
    public partial class OrderedBooksChanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CreditCard_User_UserId",
                table: "CreditCard");

            migrationBuilder.AddColumn<int>(
                name: "BookQuantity",
                table: "OrderedBook",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<Guid>(
                name: "UserId",
                table: "CreditCard",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_CreditCard_User_UserId",
                table: "CreditCard",
                column: "UserId",
                principalTable: "User",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CreditCard_User_UserId",
                table: "CreditCard");

            migrationBuilder.DropColumn(
                name: "BookQuantity",
                table: "OrderedBook");

            migrationBuilder.AlterColumn<Guid>(
                name: "UserId",
                table: "CreditCard",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddForeignKey(
                name: "FK_CreditCard_User_UserId",
                table: "CreditCard",
                column: "UserId",
                principalTable: "User",
                principalColumn: "UserId");
        }
    }
}
