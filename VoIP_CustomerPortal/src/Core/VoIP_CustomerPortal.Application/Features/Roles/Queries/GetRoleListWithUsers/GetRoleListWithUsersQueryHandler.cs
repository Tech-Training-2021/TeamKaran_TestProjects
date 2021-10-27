using AutoMapper;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using VoIP_CustomerPortal.Application.Contracts.Persistence;
using VoIP_CustomerPortal.Application.Responses;

namespace VoIP_CustomerPortal.Application.Features.Roles.Queries.GetRoleListWithUsers
{
    public class GetRoleListWithUsersQueryHandler : IRequestHandler<GetRoleListWithUsersQuery, Response<IEnumerable<RoleUserListVm>>>
    {
        private readonly IMapper _mapper;
        private readonly IRoleRepository _roleRepository;
        public GetRoleListWithUsersQueryHandler(IMapper mapper, IRoleRepository roleRepository)
        {
            _mapper = mapper;
            _roleRepository = roleRepository;
        }
        public async Task<Response<IEnumerable<RoleUserListVm>>> Handle(GetRoleListWithUsersQuery request, CancellationToken cancellationToken)
        {
            var list = await _roleRepository.GetRoleWithUsers(request.IncludeUsers);
            var roleUsersList = _mapper.Map<IEnumerable<RoleUserListVm>>(list);
            return new Response<IEnumerable<RoleUserListVm>>(roleUsersList, "success");
        }
    }
}
