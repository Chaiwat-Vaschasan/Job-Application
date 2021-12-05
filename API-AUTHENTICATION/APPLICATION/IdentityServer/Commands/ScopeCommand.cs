using DOMAIN.Models.IdentityServer;
using DOMAIN.Repository;
using IdentityServer4.EntityFramework.Mappers;
using IdentityServer4.Models;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace APPLICATION.IdentityServer.Commands
{
    public class ScopeCommand : IRequest<string>
    {
        public ApiScopeModel ScopeModel { get; set; }
    }

    public class ScopeCommandHandler : IRequestHandler<ScopeCommand, string>
    {
        #region Inject
        private readonly IUnitOfWork unit;

        public ScopeCommandHandler(IUnitOfWork unit) 
        {
            this.unit = unit;
        }
        #endregion

        #region Handle
        public async Task<string> Handle(ScopeCommand request, CancellationToken cancellationToken)
        {
            string result;
            var scope = new ApiScope(name: request.ScopeModel.Api, displayName: request.ScopeModel.Description);

            try
            {
                await unit.ScopeRepository.Add(scope.ToEntity());
                result = "Success";
            }
            catch (Exception e)
            {
                result = $"Error : {e.Message}";
            }

            return result;
            
        }
        #endregion
    }
}
