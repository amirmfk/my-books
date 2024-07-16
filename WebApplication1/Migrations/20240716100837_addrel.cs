using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    /// <inheritdoc />
    public partial class addrel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_books_Authors_Authors_AuthorId",
                table: "books_Authors");

            migrationBuilder.DropForeignKey(
                name: "FK_books_Authors_Books_BookId",
                table: "books_Authors");

            migrationBuilder.DropPrimaryKey(
                name: "PK_books_Authors",
                table: "books_Authors");

            migrationBuilder.RenameTable(
                name: "books_Authors",
                newName: "Books_Authors");

            migrationBuilder.RenameIndex(
                name: "IX_books_Authors_BookId",
                table: "Books_Authors",
                newName: "IX_Books_Authors_BookId");

            migrationBuilder.RenameIndex(
                name: "IX_books_Authors_AuthorId",
                table: "Books_Authors",
                newName: "IX_Books_Authors_AuthorId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Books_Authors",
                table: "Books_Authors",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Books_Authors_Authors_AuthorId",
                table: "Books_Authors",
                column: "AuthorId",
                principalTable: "Authors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Books_Authors_Books_BookId",
                table: "Books_Authors",
                column: "BookId",
                principalTable: "Books",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_Authors_Authors_AuthorId",
                table: "Books_Authors");

            migrationBuilder.DropForeignKey(
                name: "FK_Books_Authors_Books_BookId",
                table: "Books_Authors");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Books_Authors",
                table: "Books_Authors");

            migrationBuilder.RenameTable(
                name: "Books_Authors",
                newName: "books_Authors");

            migrationBuilder.RenameIndex(
                name: "IX_Books_Authors_BookId",
                table: "books_Authors",
                newName: "IX_books_Authors_BookId");

            migrationBuilder.RenameIndex(
                name: "IX_Books_Authors_AuthorId",
                table: "books_Authors",
                newName: "IX_books_Authors_AuthorId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_books_Authors",
                table: "books_Authors",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_books_Authors_Authors_AuthorId",
                table: "books_Authors",
                column: "AuthorId",
                principalTable: "Authors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_books_Authors_Books_BookId",
                table: "books_Authors",
                column: "BookId",
                principalTable: "Books",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
