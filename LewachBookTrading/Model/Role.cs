using System.ComponentModel.DataAnnotations;

namespace LewachBookTrading.Model
{
    public class Role
    {

        [Key]
        public int Id { get; set; }

        public string RoleName { get; set; }
        // User Management
        public bool CanCreateUser { get; set; }
        public bool CanEditUser { get; set; }
        public bool CanDeleteUser { get; set; }
        public bool CanAssignRoles { get; set; }
        public bool CanActivateDeactivateUser { get; set; }
        public bool CanViewUserActivityLogs { get; set; }

        // Content Management
        public bool CanCreateContent { get; set; }
        public bool CanEditContent { get; set; }
        public bool CanDeleteContent { get; set; }
        public bool CanApproveRejectContent { get; set; }
        public bool CanManageMediaFiles { get; set; }

        // System Configuration and Settings
        public bool CanUpdateSystemSettings { get; set; }
        public bool CanManageIntegrations { get; set; }
        public bool CanCustomizeNotifications { get; set; }

        // Security and Compliance
        public bool CanMonitorSecurityLogs { get; set; }
        public bool CanManageAccessControls { get; set; }
        public bool CanConductAudits { get; set; }
        public bool CanBackupRestoreData { get; set; }

        // Data Analytics and Reporting
        public bool CanGenerateReports { get; set; }
        public bool CanTrackSystemPerformance { get; set; }
        public bool CanAnalyzeTrends { get; set; }

        // User Support and Issue Resolution
        public bool CanRespondToUserInquiries { get; set; }
        public bool CanManageSupportTickets { get; set; }
        public bool CanBanRestrictUsers { get; set; }

        // Database Management
        public bool CanAccessDatabase { get; set; }
        public bool CanImportExportData { get; set; }
        public bool CanPerformDataCleanup { get; set; }

        // System Maintenance and Updates
        public bool CanScheduleDowntime { get; set; }
        public bool CanInstallUpdates { get; set; }
        public bool CanManageApiRateLimits { get; set; }


        [System.Text.Json.Serialization.JsonIgnore]
        public List<User>? Users { get; set; }
    }

}
