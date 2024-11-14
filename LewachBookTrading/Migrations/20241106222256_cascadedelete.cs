using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LewachBookTrading.Migrations
{
    /// <inheritdoc />
    public partial class cascadedelete : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Journals_Users_UsertId",
                table: "Journals");

            migrationBuilder.DropForeignKey(
                name: "FK_JournalTags_Users_UserId",
                table: "JournalTags");

            migrationBuilder.AddForeignKey(
                name: "FK_Journals_Users_UsertId",
                table: "Journals",
                column: "UsertId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_JournalTags_Users_UserId",
                table: "JournalTags",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Journals_Users_UsertId",
                table: "Journals");

            migrationBuilder.DropForeignKey(
                name: "FK_JournalTags_Users_UserId",
                table: "JournalTags");

            migrationBuilder.AddForeignKey(
                name: "FK_Journals_Users_UsertId",
                table: "Journals",
                column: "UsertId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_JournalTags_Users_UserId",
                table: "JournalTags",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
