using IdentityServer4.EntityFramework.Entities;
using System.Threading.Tasks;

namespace DOMAIN.Repository.IdentityServer
{
    public interface IClientsRepository
    {
        Task Add(Client client);
    }
}
