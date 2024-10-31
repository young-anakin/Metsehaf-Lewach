using LewachBookTrading.DTOs.RoleDTO;
using LewachBookTrading.Model;

namespace LewachBookTrading.Services.RoleService
{
    public interface IRoleService
    {
        Task<Role> AddRole(AddRoleDTO DTO);
        Task<Role> DeleteRole(int roleId);
        Task<List<Role>> GetRoles();
        Task<Role> GetSpecificRole(int id);
        Task<Role> UpdateRole(UpdateRoleDTO DTO);
    }
}