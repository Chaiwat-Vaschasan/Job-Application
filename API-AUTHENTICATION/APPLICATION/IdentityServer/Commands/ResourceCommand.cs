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
    public class ResourceCommand : IRequest<string>
    {
        public ApiResourceModel ResourceModel { get; set; }
    }

    public class ResourceCommandHandler : IRequestHandler<ResourceCommand, string>
    {
        #region Inject
        private readonly IUnitOfWork unit;
        public ResourceCommandHandler(IUnitOfWork unit) 
        {
            this.unit = unit;
        }
        #endregion

        #region Handle
        public async Task<string> Handle(ResourceCommand request, CancellationToken cancellationToken)
        {
            string result;
            var resource = new ApiResource(request.ResourceModel.Api, request.ResourceModel.Description);
            try
            {
                await unit.ResourceRepository.Add(resource.ToEntity());
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
