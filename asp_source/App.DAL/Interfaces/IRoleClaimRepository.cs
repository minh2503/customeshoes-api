using TFU.Models.IdentityModels;

namespace App.DAL.Interfaces
{
    public interface IRoleClaimRepository
    {
        Task<string[]> GetClaimsByUserId(long userId);
        Task<List<RoleClaimDTO>> GetRoleClaimByUserId(long userId);
    }
}