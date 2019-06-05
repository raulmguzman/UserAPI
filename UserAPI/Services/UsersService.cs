using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserAPI.Domain;
using UserAPI.Models;

namespace UserAPI.Services
{
    public class UsersService : IUsersService
    {
        private readonly IUsersDomain _userDomain;

        public UsersService(IUsersDomain userDomain)
        {
            _userDomain = userDomain;
        }
        public async Task<bool> DeleteUser(int Id)
        {
            return await _userDomain.Delete(Id);            
        }

        public User GetUser(int Id)
        {
            return _userDomain.Get(Id);
        }

        public IEnumerable<User> GetUsers()
        {
            var users = _userDomain.GetAll();
            return users;
        }

        public async Task<User> UpdateUser(User user)
        {
            return await _userDomain.Update(user);
        }
    }
}
