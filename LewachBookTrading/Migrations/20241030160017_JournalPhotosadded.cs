using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LewachBookTrading.Migrations
{
    /// <inheritdoc />
    public partial class JournalPhotosadded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_JournalPhoto_Journals_JournalId",
                table: "JournalPhoto");

            migrationBuilder.DropPrimaryKey(
                name: "PK_JournalPhoto",
                table: "JournalPhoto");

            migrationBuilder.RenameTable(
                name: "JournalPhoto",
                newName: "JournalPhotos");

            migrationBuilder.RenameIndex(
                name: "IX_JournalPhoto_JournalId",
                table: "JournalPhotos",
                newName: "IX_JournalPhotos_JournalId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_JournalPhotos",
                table: "JournalPhotos",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_JournalPhotos_Journals_JournalId",
                table: "JournalPhotos",
                column: "JournalId",
                principalTable: "Journals",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_JournalPhotos_Journals_JournalId",
                table: "JournalPhotos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_JournalPhotos",
                table: "JournalPhotos");

            migrationBuilder.RenameTable(
                name: "JournalPhotos",
                newName: "JournalPhoto");

            migrationBuilder.RenameIndex(
                name: "IX_JournalPhotos_JournalId",
                table: "JournalPhoto",
                newName: "IX_JournalPhoto_JournalId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_JournalPhoto",
                table: "JournalPhoto",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_JournalPhoto_Journals_JournalId",
                table: "JournalPhoto",
                column: "JournalId",
                principalTable: "Journals",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
