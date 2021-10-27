using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.DataProtection;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using VoIP_CustomerPortal.Application.Contracts.Persistence;
using VoIP_CustomerPortal.Application.Features.Roles.Queries.GetRoleList;
using VoIP_CustomerPortal.Application.Responses;
using VoIP_CustomerPortal.Domain.Entities;

namespace VoIP_CustomerPortal.Application.Features.Roles.Queries.GetRoleDetail
{
    public class GetRoleDetailQueryHandler : IRequestHandler<GetRoleDetailQuery, Response<RoleListVm>>
    {
        private readonly IRoleRepository _roleRepository;
        private readonly IMapper _mapper;

        //private readonly IDataProtector _protector;

        public GetRoleDetailQueryHandler(IRoleRepository roleRepository, IMapper mapper)
        {
            _roleRepository = roleRepository;
            _mapper = mapper;
            //_protector = provider.CreateProtector("");
        }
        public async Task<Response<RoleListVm>> Handle(GetRoleDetailQuery request, CancellationToken cancellationToken)
        {
            // int id = Convert.ToInt32(_protector.Unprotect(request.Id));
            int id = Convert.ToInt32(request.Id);

            var @role = await _roleRepository.GetByIdAsync(id);
            var roleDetailDto = _mapper.Map<RoleListVm>(@role);

            var response = new Response<RoleListVm>(roleDetailDto);
            return response;
        }
    }
}
