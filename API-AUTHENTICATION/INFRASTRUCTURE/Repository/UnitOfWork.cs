using DOMAIN.Repository;
using DOMAIN.Repository.IdentityServer;
using INFRASTRUCTURE.Context;
using INFRASTRUCTURE.Repository.IdentityServer;
using System.Threading.Tasks;

namespace INFRASTRUCTURE.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        #region Inject
        private readonly ApplicationDbContext applicationDbContext;
        private readonly AppPersistedGrantDbContext persistedGrantDbContext;
        private readonly AppConfigurationDbContext configurationDbContext;

        

        public UnitOfWork(ApplicationDbContext applicationDbContext , 
                          AppPersistedGrantDbContext persistedGrantDbContext,
                          AppConfigurationDbContext configurationDbContext) 
        {
            this.applicationDbContext = applicationDbContext;
            this.persistedGrantDbContext = persistedGrantDbContext;
            this.configurationDbContext = configurationDbContext;
        }
        #endregion

        #region Save
        public async Task Save()
        {
           await applicationDbContext.SaveChangesAsync();
        }

        public async Task SaveConfiguration()
        {
            await configurationDbContext.SaveChangesAsync();
        }

        public async Task SavePersistedGrant()
        {
            await persistedGrantDbContext.SaveChangesAsync();
        }
        #endregion

        #region Repository
        public IClientsRepository ClientsRepository => new ClientsRepository(configurationDbContext);
        public IResourceRepository ResourceRepository => new ResourceRepository(configurationDbContext);
        public IScopeRepository ScopeRepository => new ScopeRepository(configurationDbContext);
        #endregion

        public void Dispose()
        {
            if (applicationDbContext != null)
            {
                applicationDbContext.Dispose();
            }
            if (persistedGrantDbContext != null)
            {
                persistedGrantDbContext.Dispose();
            }
            if (configurationDbContext != null)
            {
                configurationDbContext.Dispose();
            }
        }
    }
}
