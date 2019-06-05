using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserAPI.Models;

namespace UserAPI.Domain
{
    public interface IUsersDomain
    {
        IEnumerable<User> GetAll();
        User Get(int Id);
        Task<User> Update(User user);
        Task<bool> Delete(int id);
    }
}
