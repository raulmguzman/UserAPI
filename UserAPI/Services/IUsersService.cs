using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserAPI.Models;

namespace UserAPI.Services
{
    public interface IUsersService
    {
        IEnumerable<User> GetUsers();
        User GetUser(int Id);
        Task<User> UpdateUser(User user);
        Task<bool> DeleteUser(int Id);
    }
}
