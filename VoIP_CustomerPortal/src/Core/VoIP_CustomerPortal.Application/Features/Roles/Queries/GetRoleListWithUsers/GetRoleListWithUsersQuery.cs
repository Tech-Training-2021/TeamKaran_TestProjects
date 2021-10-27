using MediatR;
using System.Collections.Generic;
using VoIP_CustomerPortal.Application.Responses;

namespace VoIP_CustomerPortal.Application.Features.Roles.Queries.GetRoleListWithUsers
{
    public class GetRoleListWithUsersQuery : IRequest<Response<IEnumerable<RoleUserListVm>>>
    {
        public bool IncludeUsers { get; set; }
    }
}
