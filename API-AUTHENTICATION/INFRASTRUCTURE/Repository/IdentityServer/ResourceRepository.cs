using DOMAIN.Repository.IdentityServer;
using IdentityServer4.EntityFramework.Entities;
using INFRASTRUCTURE.Context;
using System.Threading.Tasks;

namespace INFRASTRUCTURE.Repository.IdentityServer
{
    public class ResourceRepository : IResourceRepository
    {
        private readonly AppConfigurationDbContext context;

        public ResourceRepository(AppConfigurationDbContext context)
        {
            this.context = context;
        }

        public async Task Add(ApiResource resource)
        {
            context.ApiResources.Add(resource);
            await context.SaveChangesAsync();
        }
    }
}
