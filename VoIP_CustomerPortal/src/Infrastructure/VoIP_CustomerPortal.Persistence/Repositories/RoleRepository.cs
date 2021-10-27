using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VoIP_CustomerPortal.Application.Contracts.Persistence;
using VoIP_CustomerPortal.Domain.Entities;

namespace VoIP_CustomerPortal.Persistence.Repositories
{
    public class RoleRepository : BaseRepository<Role>, IRoleRepository
    {
        private readonly ILogger _logger;
        public RoleRepository(ApplicationDbContext dbContext, ILogger<Role> logger) : base(dbContext, logger)
        {
            _logger = logger;
        }

        public virtual async Task<Role> GetByIdAsync(int id)
        {
            return await _dbContext.Set<Role>().FindAsync(id);
        }

        public async Task<List<Role>> GetRoleWithUsers(bool includePassedEvents)
        {
            _logger.LogInformation("GetRoleWithUsers Initiated");
            var allRoles = await _dbContext.Roles.Include(x => x.Users).ToListAsync();
            
            _logger.LogInformation("GetRoleWithUsers Completed");
            return allRoles;
        }
    }
}
