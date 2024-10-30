using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LewachBookTrading.Migrations
{
    /// <inheritdoc />
    public partial class dateaddedtoUserFriend : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "StartDate",
                table: "UserFriends",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StartDate",
                table: "UserFriends");
        }
    }
}
