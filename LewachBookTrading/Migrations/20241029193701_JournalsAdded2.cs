using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LewachBookTrading.Migrations
{
    /// <inheritdoc />
    public partial class JournalsAdded2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UsertId",
                table: "Journals",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Journals_UsertId",
                table: "Journals",
                column: "UsertId");

            migrationBuilder.AddForeignKey(
                name: "FK_Journals_Users_UsertId",
                table: "Journals",
                column: "UsertId",
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

            migrationBuilder.DropIndex(
                name: "IX_Journals_UsertId",
                table: "Journals");

            migrationBuilder.DropColumn(
                name: "UsertId",
                table: "Journals");
        }
    }
}
