using AutoMapper;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using VoIP_CustomerPortal.Application.Contracts.Persistence;
using VoIP_CustomerPortal.Application.Responses;
using VoIP_CustomerPortal.Domain.Entities;

namespace VoIP_CustomerPortal.Application.Features.Users.Queries.GetUserList
{
    public class GetUserListQueryHandler : IRequestHandler<GetUserListQuery, Response<IEnumerable<UserListVm>>>
    {
        private readonly IAsyncRepository<User> _userRepository;
        private readonly IMapper _mapper;

        public GetUserListQueryHandler(IMapper mapper, IAsyncRepository<User> userRepository)
        {
            _mapper = mapper;
            _userRepository = userRepository;
        }

        public async Task<Response<IEnumerable<UserListVm>>> Handle(GetUserListQuery request, CancellationToken cancellationToken)
        {
            var allUsers = (await _userRepository.ListAllAsync()).OrderBy(x => x.UserId);
            var userList = _mapper.Map<List<UserListVm>>(allUsers);
            var response = new Response<IEnumerable<UserListVm>>(userList);
            return response;
        }
    }
}
