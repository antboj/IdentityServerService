using System.Collections.Generic;
using IdentityServer4;
using IdentityServer4.Models;

namespace IdentityServerService.Client
{
    internal class Clients
    {
        public static IEnumerable<IdentityServer4.Models.Client> Get()
        {
            return new List<IdentityServer4.Models.Client> {
                new IdentityServer4.Models.Client {
                    ClientId = "oauthClient",
                    ClientName = "Example Client Credentials Client Application",
                    AllowedGrantTypes = GrantTypes.ClientCredentials,
                    ClientSecrets = new List<Secret> {
                        new Secret("superSecretPassword".Sha256())},
                    AllowedScopes = new List<string> {"customAPI.read"}
                },
                new IdentityServer4.Models.Client
                {
                    ClientId = "mvcApp",
                    ClientName = "Other Client to connect",
                    // Tip aplikacije | Kako aplikacija komunicira sa token serverom
                    // Implicit = samo putem browsera
                    AllowedGrantTypes = GrantTypes.Implicit,
                    RequireConsent = false,
                    RedirectUris = { "http://localhost:58177/signin-oidc" , "http://localhost:58177/"},
                    AllowedScopes = new List<string>
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        IdentityServerConstants.StandardScopes.Email,
                        "role",
                        "customAPI.write"
                    },
                    PostLogoutRedirectUris = { "http://localhost:58177/" },
                    
                }
            };
        }
    }
}
