using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.DataProtection;
using System;
using System.Threading;
using System.Threading.Tasks;
using VoIP_CustomerPortal.Application.Contracts.Persistence;
using VoIP_CustomerPortal.Application.Exceptions;
using VoIP_CustomerPortal.Application.Responses;
using VoIP_CustomerPortal.Domain.Entities;

namespace VoIP_CustomerPortal.Application.Features.Roles.Commands.DeleteRole
{
    public class DeleteRoleCommandHandler : IRequestHandler<DeleteRoleCommand>
    {
        private readonly IRoleRepository _roleRepository;
        //private readonly IDataProtector _protector;

        public DeleteRoleCommandHandler(IRoleRepository roleRepository)
        {
            _roleRepository = roleRepository;
           // _protector = provider.CreateProtector("");
        }

        public async Task<Unit> Handle(DeleteRoleCommand request, CancellationToken cancellationToken)
        {
            //var roleId = new Guid(_protector.Unprotect(request.EventId));
            var roleId = request.RoleId;
            var eventToDelete = await _roleRepository.GetByIdAsync(roleId);

            if (eventToDelete == null)
            {
                throw new NotFoundException(nameof(Role), roleId);
            }

            await _roleRepository.DeleteAsync(eventToDelete);
            return Unit.Value;
        }
    }
}
