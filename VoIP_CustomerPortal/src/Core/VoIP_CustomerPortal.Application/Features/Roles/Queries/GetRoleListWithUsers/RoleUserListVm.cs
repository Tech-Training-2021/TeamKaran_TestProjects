using System;
using System.Collections.Generic;
using System.Text;

namespace VoIP_CustomerPortal.Application.Features.Roles.Queries.GetRoleListWithUsers
{
    public class RoleUserListVm
    {
        public int RoleId { get; set; }
        public string RoleName { get; set; }
        public ICollection<RoleUserDto> Users { get; set; }
    }
}
