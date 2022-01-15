using DOMAIN.Entities.Users;
using DOMAIN.Repository.IdentityServer;
using DOMAIN.Repository.Users;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DOMAIN.Repository
{
    public interface IUnitOfWork : IDisposable
    {
        IClientsRepository ClientsRepository { get; }
        IResourceRepository ResourceRepository { get; }
        IScopeRepository ScopeRepository { get; }
        IUserRepository UserRepository { get; }
        IRepositoryBase<UserRole> UserRoleRepository { get; }

        Task Save();
        Task SaveConfiguration();
        Task SavePersistedGrant();
    }
}
