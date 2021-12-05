using IdentityServer4.EntityFramework.Entities;
using System.Threading.Tasks;

namespace DOMAIN.Repository.IdentityServer
{
    public interface IScopeRepository
    {
        Task Add(ApiScope scope);
    }
}
