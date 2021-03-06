using System.Collections.Generic;


namespace DOMAIN.Models.IdentityServer
{
    public class ClientModel
    {
        public string Client { get; set; }
        public string Secret { get; set; }
        public string Uri { get; set; }
        public List<string> Scopes { get; set; }
        public int Type { get; set; }
    }
}
