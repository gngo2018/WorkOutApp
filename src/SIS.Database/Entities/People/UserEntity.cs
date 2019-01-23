using Microsoft.AspNetCore.Identity;
using WorkOut.Database.Entities.Roles;
using System;
using System.Collections.Generic;
using System.Text;

namespace WorkOut.Database.Entities.People
{
    public class UserEntity : IdentityUser<int>
    {
        public ICollection<UserRoleEntity> UserRoles { get; set; }
    }
}
