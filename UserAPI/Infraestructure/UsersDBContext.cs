using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserAPI.Models;

namespace UserAPI.Infraestructure
{
    public class UsersDBContext : DbContext
    {
        public UsersDBContext(DbContextOptions<UsersDBContext> options)
            : base(options)
        { }
        public DbSet<User> Users { get; set; }
    }
}
