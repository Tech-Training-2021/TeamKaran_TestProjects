using MediatR;
using VoIP_CustomerPortal.Application.Responses;

namespace VoIP_CustomerPortal.Application.Features.Roles.Commands.CreateRole
{
    public class CreateRoleCommand : IRequest<Response<CreateRoleDto>>
    {
        public string RoleName { get; set; }
    }
}
