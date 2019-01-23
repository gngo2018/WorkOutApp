using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using WorkOut.Database.DataContract.Authorization.RAOs;
using WorkOut.Database.DataContract.Roles.Interfaces;
using WorkOut.Database.Entities.People;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace WorkOut.Database.Roles
{
    public class RoleRepository : IRoleRepository
    {
        private readonly UserManager<UserEntity> _userManager;

        public RoleRepository(UserManager<UserEntity> userManager, IMapper mapper)
        {
            _userManager = userManager;
        }

        public async Task<bool> AddUserToRole(ReceivedExistingUserRAO User, string Role)
        {
            var user = await _userManager.Users
                  .FirstOrDefaultAsync(u => u.Id == User.Id);

            await _userManager.AddToRoleAsync(user, Role);
            return true;
        }
    }
}
