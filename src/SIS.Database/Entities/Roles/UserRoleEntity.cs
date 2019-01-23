using Microsoft.AspNetCore.Identity;
using WorkOut.Database.Entities.People;
using System;
using System.Collections.Generic;
using System.Text;

namespace WorkOut.Database.Entities.Roles
{
    public class UserRoleEntity : IdentityUserRole<int>
    {
        public UserEntity User { get; set; }
        public RoleEntity Role { get; set; }
    }
}
