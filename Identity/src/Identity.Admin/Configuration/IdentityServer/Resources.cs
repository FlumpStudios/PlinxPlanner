using System.Collections.Generic;
using IdentityModel;
using IdentityServer4.Models;

namespace Identity.Admin.Configuration.IdentityServer
{
    public class ClientResources
    {
        public static IEnumerable<IdentityResource> GetIdentityResources()
        {
            return new[]
            {
                // some standard scopes from the OIDC spec
                new IdentityResources.OpenId(),
                                new IdentityResource("profile", "User profile", new[] { "updated_at","locale", "zoneinfo", "gender", "picture","profile", "preferred_username", "nickname", "middlename","given_name", "family_name","name","website","role", "birthdate"})
                                ,
                                new IdentityResources.Email(),

                // custom identity resource with some consolidated claims
                new IdentityResource("custom.profile", new[] { JwtClaimTypes.Name, JwtClaimTypes.Email, "location" }),

                // add additional identity resource
                new IdentityResource("roles", "Roles", new[] { "role" })
            };
        }

        public static IEnumerable<ApiResource> GetApiResources()
        {
            return new[]
            {
                // simple version with ctor
                new ApiResource("api1", "Some API 1")
                                {
                    // this is needed for introspection when using reference tokens
                    ApiSecrets = { new Secret("secret".Sha256()) }
                                },
                
                // expanded version if more control is needed
                new ApiResource
                                {
                                        Name = "DealLogApi",

                                        DisplayName = "Deal Log Api",

                                        Description = "API  for the Listers Deal Log ",                                        
                                        

                                        ApiSecrets =
                                        {
                                                new Secret("secret".Sha256())
                                        },

                                        UserClaims =
                                        {
                                                JwtClaimTypes.Name,
                                                JwtClaimTypes.Email,
                                                JwtClaimTypes.Role
                                        },

                                        Scopes =
                                        {
                                                new Scope()
                                                {                                                    
                                                        Name = "DealLogApi",
                                                        Description = "Deal Log API",
                                                        Required = false,
                                                        Emphasize = false,
                                                        ShowInDiscoveryDocument = false,                       
                                                        DisplayName = "Deal Log API"
                                                }
                                        }
                                }
                        };
        }
    }
}