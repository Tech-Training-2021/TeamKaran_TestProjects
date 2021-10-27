using System;
using System.Collections.Generic;
using System.Text;

namespace VoIP_CustomerPortal.Application.Features.Customers.Queries.GetCustomerList
{
    public class CustomerListVm
    {
        public int CustomerId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Contact { get; set; }
        public string Email { get; set; }
        public CustomerType CustomerType { get; set; }
    }

    public enum CustomerType
    {
        Super_User = 0, Sub_User = 1, Demo_User = 2, New_User = 3, Admin_User = 4
    }
}
