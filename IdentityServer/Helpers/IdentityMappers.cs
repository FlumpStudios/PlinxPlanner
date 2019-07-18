using IdentityServer.Models;
using IdentityServer4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityServer.Helpers
{
    public static class IdentityMappers
    {
        public static IEnumerable<ApiResource> MapIdentityResources(IEnumerable<ApiResources> resources)
        {
            ICollection<ApiResource> result = new List<ApiResource>();

            foreach (var resource in resources)
            {
                result.Add(new ApiResource(resource.Name, resource.DisplayName));
            }
            return result;
        }

        public static IEnumerable<Client> MapIdentityClients(IEnumerable<Clients> clients)
        {
            ICollection<Client> result = new List<Client>();
            foreach (var client in clients)
            {
                result.Add(new Client
                {
                    ClientId = client.ClientId,
                    ClientName = client.ClientName,
                    AllowedGrantTypes = client.AllowedGrantTypes,
                    AllowAccessTokensViaBrowser = client.AllowAccessTokensViaBrowser,
                    RequireConsent = client.RequireConsent,
                    AccessTokenLifetime = client.AccessTokenLifetime,
                    RedirectUris = client.RedirectUris,
                    PostLogoutRedirectUris = client.PostLogoutRedirectUris,
                    AllowedCorsOrigins = client.AllowedCorsOrigins,
                    AllowedScopes = client.AllowedScopes
                });
            }
            return result;
        }

    }
}
