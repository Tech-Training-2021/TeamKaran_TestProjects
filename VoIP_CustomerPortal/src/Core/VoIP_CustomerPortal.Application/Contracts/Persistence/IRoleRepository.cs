using System.Collections.Generic;
using System.Threading.Tasks;
using VoIP_CustomerPortal.Domain.Entities;

namespace VoIP_CustomerPortal.Application.Contracts.Persistence
{
    public interface IRoleRepository : IAsyncRepository<Role>
    {
        Task<List<Role>> GetRoleWithUsers(bool includePassedEvents);
        Task<Role> GetByIdAsync(int id);
    }
}
