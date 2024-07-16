using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    /// <inheritdoc />
    public partial class Publisheradddd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_Publisher_PublisherId",
                table: "Books");

            migrationBuilder.RenameColumn(
                name: "PId",
                table: "Publisher",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "PublisherId",
                table: "Books",
                newName: "Publisher_Id");

            migrationBuilder.RenameIndex(
                name: "IX_Books_PublisherId",
                table: "Books",
                newName: "IX_Books_Publisher_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Books_Publisher_Publisher_Id",
                table: "Books",
                column: "Publisher_Id",
                principalTable: "Publisher",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_Publisher_Publisher_Id",
                table: "Books");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Publisher",
                newName: "PId");

            migrationBuilder.RenameColumn(
                name: "Publisher_Id",
                table: "Books",
                newName: "PublisherId");

            migrationBuilder.RenameIndex(
                name: "IX_Books_Publisher_Id",
                table: "Books",
                newName: "IX_Books_PublisherId");

            migrationBuilder.AddForeignKey(
                name: "FK_Books_Publisher_PublisherId",
                table: "Books",
                column: "PublisherId",
                principalTable: "Publisher",
                principalColumn: "PId");
        }
    }
}
