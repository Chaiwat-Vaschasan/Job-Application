using DOMAIN.Entities.Users;
using System;
using System.Collections.Generic;
using System.Text;

namespace DOMAIN.Repository.Users
{
    public interface IUserRepository : IRepositoryBase<User>
    {
        User FindByUsernameOrEmail(string username, string email);
        User FindByUsername(string username);

    }
}
