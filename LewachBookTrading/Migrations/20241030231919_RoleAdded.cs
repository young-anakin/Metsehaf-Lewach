using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LewachBookTrading.Migrations
{
    /// <inheritdoc />
    public partial class RoleAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RoleId",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CanCreateUser = table.Column<bool>(type: "bit", nullable: false),
                    CanEditUser = table.Column<bool>(type: "bit", nullable: false),
                    CanDeleteUser = table.Column<bool>(type: "bit", nullable: false),
                    CanAssignRoles = table.Column<bool>(type: "bit", nullable: false),
                    CanActivateDeactivateUser = table.Column<bool>(type: "bit", nullable: false),
                    CanViewUserActivityLogs = table.Column<bool>(type: "bit", nullable: false),
                    CanCreateContent = table.Column<bool>(type: "bit", nullable: false),
                    CanEditContent = table.Column<bool>(type: "bit", nullable: false),
                    CanDeleteContent = table.Column<bool>(type: "bit", nullable: false),
                    CanApproveRejectContent = table.Column<bool>(type: "bit", nullable: false),
                    CanManageMediaFiles = table.Column<bool>(type: "bit", nullable: false),
                    CanUpdateSystemSettings = table.Column<bool>(type: "bit", nullable: false),
                    CanManageIntegrations = table.Column<bool>(type: "bit", nullable: false),
                    CanCustomizeNotifications = table.Column<bool>(type: "bit", nullable: false),
                    CanMonitorSecurityLogs = table.Column<bool>(type: "bit", nullable: false),
                    CanManageAccessControls = table.Column<bool>(type: "bit", nullable: false),
                    CanConductAudits = table.Column<bool>(type: "bit", nullable: false),
                    CanBackupRestoreData = table.Column<bool>(type: "bit", nullable: false),
                    CanGenerateReports = table.Column<bool>(type: "bit", nullable: false),
                    CanTrackSystemPerformance = table.Column<bool>(type: "bit", nullable: false),
                    CanAnalyzeTrends = table.Column<bool>(type: "bit", nullable: false),
                    CanRespondToUserInquiries = table.Column<bool>(type: "bit", nullable: false),
                    CanManageSupportTickets = table.Column<bool>(type: "bit", nullable: false),
                    CanBanRestrictUsers = table.Column<bool>(type: "bit", nullable: false),
                    CanAccessDatabase = table.Column<bool>(type: "bit", nullable: false),
                    CanImportExportData = table.Column<bool>(type: "bit", nullable: false),
                    CanPerformDataCleanup = table.Column<bool>(type: "bit", nullable: false),
                    CanScheduleDowntime = table.Column<bool>(type: "bit", nullable: false),
                    CanInstallUpdates = table.Column<bool>(type: "bit", nullable: false),
                    CanManageApiRateLimits = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Users_RoleId",
                table: "Users",
                column: "RoleId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Roles_RoleId",
                table: "Users",
                column: "RoleId",
                principalTable: "Roles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Roles_RoleId",
                table: "Users");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropIndex(
                name: "IX_Users_RoleId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "RoleId",
                table: "Users");
        }
    }
}
