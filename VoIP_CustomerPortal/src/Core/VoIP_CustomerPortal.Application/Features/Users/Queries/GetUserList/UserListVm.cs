using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace VoIP_CustomerPortal.Application.Features.Users.Queries.GetUserList
{
    public class UserListVm
    {
        [Required]
        public int UserId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Contact { get; set; }
        public string Email { get; set; }
    }
}
