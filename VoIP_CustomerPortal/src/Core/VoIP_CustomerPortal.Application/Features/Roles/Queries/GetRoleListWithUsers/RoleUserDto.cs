using System;
using System.Collections.Generic;
using System.Text;

namespace VoIP_CustomerPortal.Application.Features.Roles.Queries.GetRoleListWithUsers
{
    public class RoleUserDto
    {
        public int UserId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Contact { get; set; }
        public string Email { get; set; }
        public int RoleId { get; set; }
    }
}
