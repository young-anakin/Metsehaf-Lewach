using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LewachBookTrading.Migrations
{
    /// <inheritdoc />
    public partial class PostLikeComment : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Likes_Posts_PostId",
                table: "Likes");

            migrationBuilder.DropForeignKey(
                name: "FK_Likes_Users_LikedById",
                table: "Likes");

            migrationBuilder.RenameColumn(
                name: "LikedById",
                table: "Likes",
                newName: "LikerId");

            migrationBuilder.RenameIndex(
                name: "IX_Likes_LikedById",
                table: "Likes",
                newName: "IX_Likes_LikerId");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Posts",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Posts",
                type: "nvarchar(1000)",
                maxLength: 1000,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PostedById",
                table: "Posts",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "PostId",
                table: "Likes",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "PostId1",
                table: "Likes",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CommentDescription",
                table: "Comments",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CommentedById",
                table: "Comments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Posts_PostedById",
                table: "Posts",
                column: "PostedById");

            migrationBuilder.CreateIndex(
                name: "IX_Likes_PostId1",
                table: "Likes",
                column: "PostId1");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_CommentedById",
                table: "Comments",
                column: "CommentedById");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Users_CommentedById",
                table: "Comments",
                column: "CommentedById",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Likes_Posts_PostId",
                table: "Likes",
                column: "PostId",
                principalTable: "Posts",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Likes_Posts_PostId1",
                table: "Likes",
                column: "PostId1",
                principalTable: "Posts",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Likes_Users_LikerId",
                table: "Likes",
                column: "LikerId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_Users_PostedById",
                table: "Posts",
                column: "PostedById",
                principalTable: "Users",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Users_CommentedById",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Likes_Posts_PostId",
                table: "Likes");

            migrationBuilder.DropForeignKey(
                name: "FK_Likes_Posts_PostId1",
                table: "Likes");

            migrationBuilder.DropForeignKey(
                name: "FK_Likes_Users_LikerId",
                table: "Likes");

            migrationBuilder.DropForeignKey(
                name: "FK_Posts_Users_PostedById",
                table: "Posts");

            migrationBuilder.DropIndex(
                name: "IX_Posts_PostedById",
                table: "Posts");

            migrationBuilder.DropIndex(
                name: "IX_Likes_PostId1",
                table: "Likes");

            migrationBuilder.DropIndex(
                name: "IX_Comments_CommentedById",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "PostedById",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "PostId1",
                table: "Likes");

            migrationBuilder.DropColumn(
                name: "CommentedById",
                table: "Comments");

            migrationBuilder.RenameColumn(
                name: "LikerId",
                table: "Likes",
                newName: "LikedById");

            migrationBuilder.RenameIndex(
                name: "IX_Likes_LikerId",
                table: "Likes",
                newName: "IX_Likes_LikedById");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Posts",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Posts",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(1000)",
                oldMaxLength: 1000,
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "PostId",
                table: "Likes",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CommentDescription",
                table: "Comments",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500,
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Likes_Posts_PostId",
                table: "Likes",
                column: "PostId",
                principalTable: "Posts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Likes_Users_LikedById",
                table: "Likes",
                column: "LikedById",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
