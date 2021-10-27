using MediatR;
using System;

namespace VoIP_CustomerPortal.Application.Features.Roles.Commands.DeleteRole
{
    public class DeleteRoleCommand : IRequest
    {
        public int RoleId { get; set; }
    }
}
