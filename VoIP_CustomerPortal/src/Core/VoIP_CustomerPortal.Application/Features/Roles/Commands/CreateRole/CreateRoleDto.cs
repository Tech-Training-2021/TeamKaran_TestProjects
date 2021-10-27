using System;
using System.Collections.Generic;
using System.Text;

namespace VoIP_CustomerPortal.Application.Features.Roles.Commands.CreateRole
{
    public class CreateRoleDto
    {
        public int RoleId { get; set; }
        public string RoleName { get; set; }
    }
}
