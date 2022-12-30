using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Twitter.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class SecondMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Tweets_IdComment",
                table: "Comments");

            migrationBuilder.RenameColumn(
                name: "IdComment",
                table: "Comments",
                newName: "IdTweet");

            migrationBuilder.RenameIndex(
                name: "IX_Comments_IdComment",
                table: "Comments",
                newName: "IX_Comments_IdTweet");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Tweets_IdTweet",
                table: "Comments",
                column: "IdTweet",
                principalTable: "Tweets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Tweets_IdTweet",
                table: "Comments");

            migrationBuilder.RenameColumn(
                name: "IdTweet",
                table: "Comments",
                newName: "IdComment");

            migrationBuilder.RenameIndex(
                name: "IX_Comments_IdTweet",
                table: "Comments",
                newName: "IX_Comments_IdComment");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Tweets_IdComment",
                table: "Comments",
                column: "IdComment",
                principalTable: "Tweets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
