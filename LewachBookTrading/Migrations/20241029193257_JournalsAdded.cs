using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LewachBookTrading.Migrations
{
    /// <inheritdoc />
    public partial class JournalsAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Journals",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    JournalName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    JournalContent = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    JournalEntryDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    JournalUpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    JournalTagsId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Journals", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Journals_JournalTags_JournalTagsId",
                        column: x => x.JournalTagsId,
                        principalTable: "JournalTags",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "JournalPhoto",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PhotoUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    JournalId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JournalPhoto", x => x.Id);
                    table.ForeignKey(
                        name: "FK_JournalPhoto_Journals_JournalId",
                        column: x => x.JournalId,
                        principalTable: "Journals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_JournalPhoto_JournalId",
                table: "JournalPhoto",
                column: "JournalId");

            migrationBuilder.CreateIndex(
                name: "IX_Journals_JournalTagsId",
                table: "Journals",
                column: "JournalTagsId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "JournalPhoto");

            migrationBuilder.DropTable(
                name: "Journals");
        }
    }
}
