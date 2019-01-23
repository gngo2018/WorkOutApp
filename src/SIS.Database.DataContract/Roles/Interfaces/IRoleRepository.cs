using System.Threading.Tasks;
using WorkOut.Database.DataContract.Authorization.RAOs;

namespace WorkOut.Database.DataContract.Roles.Interfaces
{
    public interface IRoleRepository
    {
        Task<bool> AddUserToRole(ReceivedExistingUserRAO User, string Role);
    }
}