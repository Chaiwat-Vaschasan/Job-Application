using DOMAIN.Repository.IdentityServer;
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

        Task Save();
        Task SaveConfiguration();
        Task SavePersistedGrant();
    }
}
