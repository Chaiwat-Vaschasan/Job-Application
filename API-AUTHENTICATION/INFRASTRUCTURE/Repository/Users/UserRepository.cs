using DOMAIN.Entities.Users;
using DOMAIN.Repository.Users;
using INFRASTRUCTURE.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace INFRASTRUCTURE.Repository.Users
{
    public class UserRepository : RepositoryBase<User> , IUserRepository
    {
        private new readonly ApplicationDbContext context;

        public UserRepository(ApplicationDbContext context) : base(context) 
        {
            this.context = context;
        }

        public User FindByUsername(string username)
        {
            return context.Users.Where(x => x.Username == username).FirstOrDefault();
        }

        public  User FindByUsernameOrEmail(string username, string email)
        {
            return context.Users.Where(x => x.Username == username || x.Email == email).FirstOrDefault();
        }
    }
}
