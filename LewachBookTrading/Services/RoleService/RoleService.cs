using LewachBookTrading.Context;
using LewachBookTrading.DTOs.RoleDTO;
using LewachBookTrading.Model;
using Microsoft.EntityFrameworkCore;

namespace LewachBookTrading.Services.RoleService
{
    public class RoleService : IRoleService
    {
        private readonly DataContext _context;
        public RoleService(DataContext context)
        {
            _context = context;
        }
        public async Task<Role> AddRole(AddRoleDTO DTO)
        {
            Role role = new Role
            {
                RoleName = DTO.RoleName,
                CanAccessDatabase = DTO.CanAccessDatabase,
                CanCreateUser = DTO.CanCreateUser,
                CanEditUser = DTO.CanEditUser,
                CanDeleteUser = DTO.CanDeleteUser,
                CanAssignRoles = DTO.CanAssignRoles,
                CanActivateDeactivateUser = DTO.CanActivateDeactivateUser,
                CanViewUserActivityLogs = DTO.CanViewUserActivityLogs,

                // Content Management
                CanCreateContent = DTO.CanCreateContent,
                CanEditContent = DTO.CanEditContent,
                CanDeleteContent = DTO.CanDeleteContent,
                CanApproveRejectContent = DTO.CanApproveRejectContent,
                CanManageMediaFiles = DTO.CanManageMediaFiles,

                // System Configuration and Settings
                CanUpdateSystemSettings = DTO.CanUpdateSystemSettings,
                CanManageIntegrations = DTO.CanManageIntegrations,
                CanCustomizeNotifications = DTO.CanCustomizeNotifications,

                // Security and Compliance
                CanMonitorSecurityLogs = DTO.CanMonitorSecurityLogs,
                CanManageAccessControls = DTO.CanManageAccessControls,
                CanConductAudits = DTO.CanConductAudits,
                CanBackupRestoreData = DTO.CanBackupRestoreData,

                // Data Analytics and Reporting
                CanGenerateReports = DTO.CanGenerateReports,
                CanTrackSystemPerformance = DTO.CanTrackSystemPerformance,
                CanAnalyzeTrends = DTO.CanAnalyzeTrends,

                // User Support and Issue Resolution
                CanRespondToUserInquiries = DTO.CanRespondToUserInquiries,
                CanManageSupportTickets = DTO.CanManageSupportTickets,
                CanBanRestrictUsers = DTO.CanBanRestrictUsers,

                // Database Management
                CanImportExportData = DTO.CanImportExportData,
                CanPerformDataCleanup = DTO.CanPerformDataCleanup,

                // System Maintenance and Updates
                CanScheduleDowntime = DTO.CanScheduleDowntime,
                CanInstallUpdates = DTO.CanInstallUpdates,
                CanManageApiRateLimits = DTO.CanManageApiRateLimits
            };

            // Assuming _context is your DbContext instance, and you're adding the role to the database.
            await _context.Roles.AddAsync(role);
            await _context.SaveChangesAsync();

            return role;
        }

        public async Task<Role> UpdateRole(UpdateRoleDTO DTO)
        {
            var role = await _context.Roles.FirstOrDefaultAsync(r => r.Id == DTO.RoleId);
            if (role == null)
            {
                // Handle the case where the role is not found
                throw new Exception("Role not found.");
            }
            role.RoleName = DTO.RoleName;
            role.CanAccessDatabase = DTO.CanAccessDatabase;
            role.CanCreateUser = DTO.CanCreateUser;
            role.CanEditUser = DTO.CanEditUser;
            role.CanDeleteUser = DTO.CanDeleteUser;
            role.CanAssignRoles = DTO.CanAssignRoles;
            role.CanActivateDeactivateUser = DTO.CanActivateDeactivateUser;
            role.CanViewUserActivityLogs = DTO.CanViewUserActivityLogs;

            // Content Management
            role.CanCreateContent = DTO.CanCreateContent;
            role.CanEditContent = DTO.CanEditContent;
            role.CanDeleteContent = DTO.CanDeleteContent;
            role.CanApproveRejectContent = DTO.CanApproveRejectContent;
            role.CanManageMediaFiles = DTO.CanManageMediaFiles;

            // System Configuration and Settings
            role.CanUpdateSystemSettings = DTO.CanUpdateSystemSettings;
            role.CanManageIntegrations = DTO.CanManageIntegrations;
            role.CanCustomizeNotifications = DTO.CanCustomizeNotifications;

            // Security and Compliance
            role.CanMonitorSecurityLogs = DTO.CanMonitorSecurityLogs;
            role.CanManageAccessControls = DTO.CanManageAccessControls;
            role.CanConductAudits = DTO.CanConductAudits;
            role.CanBackupRestoreData = DTO.CanBackupRestoreData;

            // Data Analytics and Reporting
            role.CanGenerateReports = DTO.CanGenerateReports;
            role.CanTrackSystemPerformance = DTO.CanTrackSystemPerformance;
            role.CanAnalyzeTrends = DTO.CanAnalyzeTrends;

            // User Support and Issue Resolution
            role.CanRespondToUserInquiries = DTO.CanRespondToUserInquiries;
            role.CanManageSupportTickets = DTO.CanManageSupportTickets;
            role.CanBanRestrictUsers = DTO.CanBanRestrictUsers;

            // Database Management
            role.CanImportExportData = DTO.CanImportExportData;
            role.CanPerformDataCleanup = DTO.CanPerformDataCleanup;

            // System Maintenance and Updates
            role.CanScheduleDowntime = DTO.CanScheduleDowntime;
            role.CanInstallUpdates = DTO.CanInstallUpdates;
            role.CanManageApiRateLimits = DTO.CanManageApiRateLimits;


            _context.Roles.Update(role);
            await _context.SaveChangesAsync();
            return role;

        }

        public async Task<Role> DeleteRole(int roleId)
        {
            var role = await _context.Roles.FirstOrDefaultAsync(r => r.Id == roleId);
            if (role == null)
            {
                throw new Exception("Role Not Found");
            }

            _context.Roles.Remove(role);
            await _context.SaveChangesAsync();
            return role;
        }

        public async Task<Role> GetSpecificRole(int id)
        {
            var role = await _context.Roles.FirstOrDefaultAsync(r => r.Id == id);
            if (role == null)
            {
                throw new Exception("Role Not Found.");
            }
            return role;
        }

        public async Task<List<Role>> GetRoles()
        {
            var role = await _context.Roles.ToListAsync();
            return role;
        }


    }
}
