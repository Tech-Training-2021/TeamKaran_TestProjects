using AutoMapper;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using VoIP_CustomerPortal.Application.Contracts.Persistence;
using VoIP_CustomerPortal.Application.Exceptions;
using VoIP_CustomerPortal.Application.Responses;
using VoIP_CustomerPortal.Domain.Entities;

namespace VoIP_CustomerPortal.Application.Features.Roles.Commands.UpdateRole
{
    public class UpdateRoleCommandHandler : IRequestHandler<UpdateRoleCommand, Response<int>>
    {
        private readonly IRoleRepository _roleRepository;
        private readonly IMapper _mapper;

        public UpdateRoleCommandHandler(IMapper mapper, IRoleRepository roleRepository)
        {
            _mapper = mapper;
            _roleRepository = roleRepository;
        }
        public async Task<Response<int>> Handle(UpdateRoleCommand request, CancellationToken cancellationToken)
        {
            var roleToUpdate = await _roleRepository.GetByIdAsync(request.RoleId);

            if (roleToUpdate == null)
            {
                throw new NotFoundException(nameof(Role), request.RoleId);
            }

            var validator = new UpdateRoleCommandValidator();
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Count > 0)
                throw new ValidationException(validationResult);

            _mapper.Map(request, roleToUpdate, typeof(UpdateRoleCommand), typeof(Role));

            await _roleRepository.UpdateAsync(roleToUpdate);

            return new Response<int>(request.RoleId, "Updated successfully ");
        }
    }
}
