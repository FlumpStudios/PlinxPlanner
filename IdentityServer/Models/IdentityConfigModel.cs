using System.Collections.Generic;

namespace IdentityServer.Models
{
    public class IdentityConfigModel
    {
        public IEnumerable<ApiResources> ApiResources { get; set; }
        public IEnumerable<Clients> Clients { get; set; }

    }

    public class ApiResources
    {
        public string Name { get; set; }
        public string DisplayName { get; set; }     
    }

    public class Clients
    {
        public string ClientId { get; set; }

        public string ClientName { get; set; }

        public bool AllowAccessTokensViaBrowser { get; set; }

        public bool RequireConsent  { get; set; }

        public int AccessTokenLifetime { get; set; }

        public ICollection<string> RedirectUris { get; set; }

        public ICollection<string> PostLogoutRedirectUris { get; set; }

        public ICollection<string> AllowedCorsOrigins { get; set; }

        public ICollection<string> AllowedScopes { get; set; }

        public ICollection<string>  AllowedGrantTypes { get; set; }
    }
}
