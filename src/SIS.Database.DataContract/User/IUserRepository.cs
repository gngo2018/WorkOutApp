using WorkOut.Database.DataContract.Authorization.RAOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace WorkOut.Database.DataContract.User
{
    public interface IUserRepository
    {
        Task<ReceivedExistingUserRAO> GetUser(int userId);
    }
}
