using IdentityServer.Helpers;
using IdentityServer.Models;
using IdentityServer4.Models;
using System.Collections.Generic;

namespace IdentityServerWithAspNetIdentity
{
    public class Config
    {
        public static IEnumerable<IdentityResource> GetIdentityResources()
        {
            return new List<IdentityResource> {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),
            };
        }

        public static IEnumerable<ApiResource> GetApiResources(IEnumerable<ApiResources> resources)
        {
            return IdentityMappers.MapIdentityResources(resources);
        }        

        public static IEnumerable<Client> GetClients(IEnumerable<Clients> clients)
        {
            return IdentityMappers.MapIdentityClients(clients);
        }


    }
}