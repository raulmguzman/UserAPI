using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserAPI.Infraestructure;
using UserAPI.Models;

namespace UserAPI.Domain
{
   
    public class UsersDomain : IUsersDomain
    {
        private readonly UsersDBContext _usersDBContext;

        public UsersDomain(UsersDBContext usersDBContext)
        {
            _usersDBContext = usersDBContext;
        }
        public async Task<bool> Delete(int id)
        {
            var userToDelete = _usersDBContext.Users.Where(u => u.Id == id).FirstOrDefault();
            if (userToDelete == null)
            {
                return false;
            }
            var user = _usersDBContext.Users.Remove(userToDelete);
            await _usersDBContext.SaveChangesAsync().ConfigureAwait(false);
            return true;
        }

        public User Get(int Id)
        {
            var user = _usersDBContext.Users.Where(u => u.Id == Id).FirstOrDefault();
            return user;
        }

        public IEnumerable<User> GetAll()
        {
            return _usersDBContext.Users;
        }

        public async Task<User> Update(User user)
        {
            if(_usersDBContext.Users.Any(u => u.Id == user.Id))
            {
                var updatedUser =  _usersDBContext.Users.Update(user);
                await _usersDBContext.SaveChangesAsync().ConfigureAwait(false);
            }
            else
            {
                var createUser = await _usersDBContext.Set<User>().AddAsync(user).ConfigureAwait(false);
                await _usersDBContext.SaveChangesAsync().ConfigureAwait(false);
            }
            
            return user;
        }
    }
}
