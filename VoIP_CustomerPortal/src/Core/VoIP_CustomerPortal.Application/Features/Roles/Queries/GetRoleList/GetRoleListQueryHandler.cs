using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using VoIP_CustomerPortal.Application.Contracts.Persistence;
using VoIP_CustomerPortal.Application.Responses;

namespace VoIP_CustomerPortal.Application.Features.Roles.Queries.GetRoleList
{
    public class GetRoleListQueryHandler : IRequestHandler<GetRoleListQuery, Response<IEnumerable<RoleListVm>>>
    {
        private readonly IRoleRepository _roleRepository;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;
        public GetRoleListQueryHandler(IMapper mapper, IRoleRepository roleRepository, ILogger<GetRoleListQueryHandler> logger)
        {
            _mapper = mapper;
            _roleRepository = roleRepository;
            _logger = logger;
        }
        public async Task<Response<IEnumerable<RoleListVm>>> Handle(GetRoleListQuery request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Handle Initiated");
            var allRoles = (await _roleRepository.ListAllAsync()).OrderBy(x => x.RoleName);
            var role = _mapper.Map<IEnumerable<RoleListVm>>(allRoles);
            _logger.LogInformation("Hanlde Completed");
            return new Response<IEnumerable<RoleListVm>>(role, "success");
        }
    }
}
