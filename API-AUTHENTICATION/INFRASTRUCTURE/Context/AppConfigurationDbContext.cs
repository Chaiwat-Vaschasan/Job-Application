using IdentityServer4.EntityFramework.DbContexts;
using IdentityServer4.EntityFramework.Options;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace INFRASTRUCTURE.Context
{
    public class AppConfigurationDbContext : ConfigurationDbContext
    {
        public AppConfigurationDbContext(DbContextOptions<ConfigurationDbContext> options, ConfigurationStoreOptions storeOptions) : base(options, storeOptions)
        {
        }
    }
}
