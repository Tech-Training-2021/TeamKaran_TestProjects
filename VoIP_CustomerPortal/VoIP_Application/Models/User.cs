using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VoIP_Application.Models
{
    public class User
    {
        public int userId { get; set; }

        public string username { get; set; }

        public string password { get; set; }

        public string contact { get; set; }

        public string email { get; set; }
    }
}