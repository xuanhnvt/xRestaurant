﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IdentityServer4;
using IdentityServer4.Models;

namespace IdentityServer
{
    public static class Config
    {
        public static IEnumerable<IdentityResource> IdentityResources =>
            new List<IdentityResource>
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),
            };

        public static IEnumerable<ApiScope> ApiScopes =>
            new List<ApiScope>
            {
                new ApiScope("catalog", "xRestaurant Catalog")
            };

        public static IEnumerable<Client> Clients =>
            new List<Client>
            {
                new Client
                {
                    ClientId = "client",

                    // no interactive user, use the clientid/secret for authentication
                    AllowedGrantTypes = GrantTypes.ClientCredentials,
                    // secret for authentication
                    ClientSecrets =
                    {
                        new Secret("secret".Sha256())
                    },
                    // scopes that client has access to
                    AllowedScopes = { "catalog" }
                },
                // interactive ASP.NET Core MVC client
        new Client
        {
            ClientId = "mvc",
            //ClientSecrets = { new Secret("secret".Sha256()) },
            RequireClientSecret = false,
            AllowedGrantTypes = GrantTypes.Code,
            // where to redirect to after login
            RedirectUris = { "https://localhost:44338/signin-oidc" },
            // where to redirect to after logout
            PostLogoutRedirectUris = { "https://localhost:44338/signout-callback-oidc" },
            AllowOfflineAccess = true,
            AllowedScopes = new List<string>
            {
                IdentityServerConstants.StandardScopes.OpenId,
                IdentityServerConstants.StandardScopes.Profile,
                "catalog"
            }
        },
        // JavaScript Client
new Client
{
    ClientId = "angular_spa",
    ClientName = "Angular 4 Client",
    AllowedGrantTypes = GrantTypes.Code,
    RequireClientSecret = false,
    RequirePkce = true,

    RedirectUris = new List<string> {"http://localhost:4200/auth-callback", "http://localhost:4200/silent-refresh.html"},
    PostLogoutRedirectUris = new List<string> {"http://localhost:4200/"},
    AllowedCorsOrigins = new List<string> {"http://localhost:4200"},

    AllowedScopes =
    {
        IdentityServerConstants.StandardScopes.OpenId,
        IdentityServerConstants.StandardScopes.Profile,
        "catalog"
    },
                AllowAccessTokensViaBrowser = true
}
            };
    }
}
