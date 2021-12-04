using DOMAIN.Repository.IdentityServer;
using IdentityServer4.EntityFramework.Entities;
using INFRASTRUCTURE.Context;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace INFRASTRUCTURE.Repository.IdentityServer
{
    public class ClientsRepository : IClientsRepository
    {
        private readonly AppConfigurationDbContext context;

        public ClientsRepository(AppConfigurationDbContext context ) 
        {
            this.context = context;
        }

        public async Task Add(Client client)
        {
            context.Clients.Add(client);
            await context.SaveChangesAsync();
        }
    }
}
