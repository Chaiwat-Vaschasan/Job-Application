using DOMAIN.Models.IdentityServer;
using DOMAIN.Repository;
using IdentityServer4;
using IdentityServer4.EntityFramework.Mappers;
using IdentityServer4.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using static DOMAIN.Common.IdentityServerConstant;

namespace APPLICATION.IdentityServer.Commands
{
    public class ClientCommand : IRequest<string>
    {
        public ClientModel ClientModel { get; set; }
    }

    public class ClientCommandHandler : IRequestHandler<ClientCommand, string>
    {
        #region Inject
        private readonly IUnitOfWork unit;

        public ClientCommandHandler(IUnitOfWork unit) 
        {
            this.unit = unit;
        }
        #endregion

        #region Handle
        public async Task<string> Handle(ClientCommand request, CancellationToken cancellationToken)
        {
            #region Init
            string result;
            var client = new Client()
            {
                ClientId = request.ClientModel.Client,
                ClientName = request.ClientModel.Client,
                ClientSecrets = { new Secret(request.ClientModel.Secret.Sha256()) },
                AllowedScopes = request.ClientModel.Scopes
            };
            #endregion

            #region Update Client Type
            if (request.ClientModel.Type == ClientType.CREDENTIALS)
            {
                client.AllowedGrantTypes = GrantTypes.ClientCredentials;
                client.AccessTokenLifetime = 3600;
            }
            else if (request.ClientModel.Type == ClientType.PASSWORD)
            {
                client.AllowedGrantTypes = GrantTypes.ClientCredentials;
                client.AllowOfflineAccess = true;
                client.AbsoluteRefreshTokenLifetime = 604800;
                client.AccessTokenLifetime = 1800;
                client.AllowedScopes.Add(IdentityServerConstants.StandardScopes.OfflineAccess);
                client.AllowedScopes.Add(IdentityServerConstants.StandardScopes.OpenId);
            }
            else if (request.ClientModel.Type == ClientType.CODE)
            {
                client.AllowedGrantTypes = GrantTypes.Code;
                client.AllowOfflineAccess = true;
                client.AbsoluteRefreshTokenLifetime = 604800;
                client.AccessTokenLifetime = 1800;
                client.RedirectUris = new List<string>() {request.ClientModel.Uri};
                client.AllowedScopes.Add(IdentityServerConstants.StandardScopes.OfflineAccess);
                client.AllowedScopes.Add(IdentityServerConstants.StandardScopes.OpenId);
            }
            else 
            {
                result = "Error : Not support client type";
                return result;
            }
            #endregion

            #region Save Client
            try
            {
                await unit.ClientsRepository.Add(client.ToEntity());
                result = "Success";
            }
            catch (Exception e)
            {
                result = $"Error : {e.Message}";
            }
            return result;
            #endregion
        }
        #endregion
    }
}
