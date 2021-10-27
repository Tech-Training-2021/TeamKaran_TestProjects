using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using VoIP_CustomerPortal.Application.Responses;

namespace VoIP_CustomerPortal.Application.Features.Users.Queries.GetUserList
{
    public class GetUserListQuery : IRequest<Response<IEnumerable<UserListVm>>>
    {
    }
}
