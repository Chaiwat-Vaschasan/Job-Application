using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DOMAIN.Repository
{
    public interface IUnitOfWork : IDisposable
    {
        Task Save();
    }
}
