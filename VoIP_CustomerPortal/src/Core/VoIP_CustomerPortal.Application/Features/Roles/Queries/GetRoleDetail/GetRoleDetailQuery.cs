using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using VoIP_CustomerPortal.Application.Features.Roles.Queries.GetRoleList;
using VoIP_CustomerPortal.Application.Responses;

namespace VoIP_CustomerPortal.Application.Features.Roles.Queries.GetRoleDetail
{
    public class GetRoleDetailQuery : IRequest<Response<RoleListVm>>
    {
        public string Id { get; set; }
    }
}
