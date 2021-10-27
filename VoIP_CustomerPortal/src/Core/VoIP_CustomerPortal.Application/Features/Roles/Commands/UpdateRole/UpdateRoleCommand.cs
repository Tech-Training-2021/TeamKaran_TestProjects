using MediatR;
using System;
using VoIP_CustomerPortal.Application.Responses;
namespace VoIP_CustomerPortal.Application.Features.Roles.Commands.UpdateRole
{
    public class UpdateRoleCommand : IRequest<Response<int>>
    {
        public int RoleId { get; set; }
        public string RoleName { get; set; }
    }
}
