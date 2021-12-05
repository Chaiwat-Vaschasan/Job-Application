using DOMAIN.Repository.IdentityServer;
using IdentityServer4.EntityFramework.Entities;
using INFRASTRUCTURE.Context;
using System.Threading.Tasks;

namespace INFRASTRUCTURE.Repository.IdentityServer
{
    public class ScopeRepository : IScopeRepository
    {
        private readonly AppConfigurationDbContext context;

        public ScopeRepository(AppConfigurationDbContext context) 
        {
            this.context = context;
        }

        public async Task Add(ApiScope scope)
        {
            context.ApiScopes.Add(scope);
            await context.SaveChangesAsync();
        }
    }
}
