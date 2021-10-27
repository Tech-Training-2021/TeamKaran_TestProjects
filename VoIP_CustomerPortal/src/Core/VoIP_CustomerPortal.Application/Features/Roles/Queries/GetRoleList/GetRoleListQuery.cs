using MediatR;
using System.Collections.Generic;
using VoIP_CustomerPortal.Application.Responses;

namespace VoIP_CustomerPortal.Application.Features.Roles.Queries.GetRoleList
{
    public class GetRoleListQuery : IRequest<Response<IEnumerable<RoleListVm>>>
    {
    }
}
