using System;
using System.Collections.Generic;
using System.Text;

namespace DOMAIN.Models.Users
{
    public class UserModel
    {
        public Guid Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Tel { get; set; }
        public string Address { get; set; }
        public List<RoleModel> Roles { get; set; }
    }
}
