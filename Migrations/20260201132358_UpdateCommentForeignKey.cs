using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TPfinal_BlogAPI.Migrations
{
    /// <inheritdoc />
    public partial class UpdateCommentForeignKey : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Articles_Article_id",
                table: "Comments");

            migrationBuilder.RenameColumn(
                name: "Article_id",
                table: "Comments",
                newName: "ArticleId");

            migrationBuilder.RenameIndex(
                name: "IX_Comments_Article_id",
                table: "Comments",
                newName: "IX_Comments_ArticleId");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Articles_ArticleId",
                table: "Comments",
                column: "ArticleId",
                principalTable: "Articles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Articles_ArticleId",
                table: "Comments");

            migrationBuilder.RenameColumn(
                name: "ArticleId",
                table: "Comments",
                newName: "Article_id");

            migrationBuilder.RenameIndex(
                name: "IX_Comments_ArticleId",
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
    }
}
