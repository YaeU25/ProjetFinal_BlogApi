using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TPfinal_BlogAPI.Migrations
{
    /// <inheritdoc />
    public partial class inition : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Articles_article_id",
                table: "Comments");

            migrationBuilder.RenameColumn(
                name: "author",
                table: "Comments",
                newName: "Author");

            migrationBuilder.RenameColumn(
                name: "article_id",
                table: "Comments",
                newName: "Article_id");

            migrationBuilder.RenameIndex(
                name: "IX_Comments_article_id",
                table: "Comments",
                newName: "IX_Comments_Article_id");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Articles_Article_id",
                table: "Comments",
                column: "Article_id",
                principalTable: "Articles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Articles_Article_id",
                table: "Comments");

            migrationBuilder.RenameColumn(
                name: "Author",
                table: "Comments",
                newName: "author");

            migrationBuilder.RenameColumn(
                name: "Article_id",
                table: "Comments",
                newName: "article_id");

            migrationBuilder.RenameIndex(
                name: "IX_Comments_Article_id",
                table: "Comments",
                newName: "IX_Comments_article_id");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Articles_article_id",
                table: "Comments",
                column: "article_id",
                principalTable: "Articles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
