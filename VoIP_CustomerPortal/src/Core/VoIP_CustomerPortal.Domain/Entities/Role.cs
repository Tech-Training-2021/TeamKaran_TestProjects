using System;
using System.Collections.Generic;
using System.Text;

namespace VoIP_CustomerPortal.Domain.Entities
{
    public class Role
    {
        public int RoleId { get; set; }
        public string RoleName { get; set; }
        public ICollection<User> Users { get; set; }
    }
}
