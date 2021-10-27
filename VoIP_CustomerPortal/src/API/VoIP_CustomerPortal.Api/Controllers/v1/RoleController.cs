using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VoIP_CustomerPortal.Application.Features.Roles.Commands.CreateRole;
using VoIP_CustomerPortal.Application.Features.Roles.Commands.DeleteRole;
using VoIP_CustomerPortal.Application.Features.Roles.Commands.UpdateRole;
using VoIP_CustomerPortal.Application.Features.Roles.Queries.GetRoleDetail;
using VoIP_CustomerPortal.Application.Features.Roles.Queries.GetRoleList;
using VoIP_CustomerPortal.Application.Features.Roles.Queries.GetRoleListWithUsers;

namespace VoIP_CustomerPortal.Api.Controllers.v1
{
    [ApiVersion("1")]
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger _logger;

        public RoleController(IMediator mediator, ILogger<RoleController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        //[Authorize]
        [HttpGet("all", Name = "GetAllRoles")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult> GetAllRoles()
        {
            _logger.LogInformation("GetAllRoles Initiated");
            var dtos = await _mediator.Send(new GetRoleListQuery());
            _logger.LogInformation("GetAllRoles Completed");
            return Ok(dtos);
        }

        //[Authorize]
        [HttpGet("allwithusers", Name = "GetRolesWithUsers")]
        [ProducesDefaultResponseType]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult> GetRolesWithUsers(bool includeUsers)
        {
            GetRoleListWithUsersQuery getRoleListWithUsersQuery = new GetRoleListWithUsersQuery() { IncludeUsers = includeUsers };

            var dtos = await _mediator.Send(getRoleListWithUsersQuery);
            return Ok(dtos);
        }

        [HttpGet("{id}", Name = "GetRoleById")]
        public async Task<ActionResult> GetRoleById(string id)
        {
            var getRoleDetailQuery = new GetRoleDetailQuery() { Id = id };
            return Ok(await _mediator.Send(getRoleDetailQuery));
        }

        [HttpPost(Name = "AddRole")]
        public async Task<ActionResult> Create([FromBody] CreateRoleCommand createRoleCommand)
        {
            var response = await _mediator.Send(createRoleCommand);
            return Ok(response);
        }

        [HttpPut(Name = "UpdateRole")]
        //[ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Update([FromBody] UpdateRoleCommand updateRoleCommand)
        {
            var response = await _mediator.Send(updateRoleCommand);
            return Ok(response);
        }

        [HttpDelete("{id}", Name = "DeleteRole")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Delete(int id)
        {
            var deleteRoleCommand = new DeleteRoleCommand() { RoleId = id };
            await _mediator.Send(deleteRoleCommand);
            return NoContent();
        }
    }
}
