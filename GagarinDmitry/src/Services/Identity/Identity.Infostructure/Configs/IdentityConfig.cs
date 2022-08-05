using IdentityModel;
using IdentityServer4;
using IdentityServer4.Models;

namespace Identity.Infostructure.Configs
{
    /// <summary>
    /// Provides Identity configuration
    /// </summary>
    public static class IdentityConfig
    {
        /// <summary>
        ///  Provides ApiResources configuration
        /// </summary>
        public static IEnumerable<ApiResource> ApiResources =>
           new List<ApiResource>
           {
                new("Catalog", "CatalogRoute")
                {
                    UserClaims =
                    {
                        JwtClaimTypes.Audience,
                        JwtClaimTypes.Role
                    },
                    Scopes =
                    {
                        "Catalog"
                    }
                },
                new("Basket", "BasketRoute")
                {
                    UserClaims =
                    {
                        JwtClaimTypes.Audience,
                        JwtClaimTypes.Role
                    },
                    Scopes =
                    {
                        "Basket"
                    }
                }
           };

        /// <summary>
        /// Provides IdentityResources configuration
        /// </summary>
        public static IEnumerable<IdentityResource> IdentityResources =>
            new List<IdentityResource>
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile()
            };

        /// <summary>
        /// Provides ApiScopes configuration
        /// </summary
        public static IEnumerable<ApiScope> ApiScopes =>
            new List<ApiScope>
            {
                new ApiScope("Catalog", "CatalogScope"),
                new ApiScope("Basket", "BasketScope")
            };

        /// <summary>
        /// Provides Clients configuration
        /// </summary>
        public static IEnumerable<Client> Clients =>
            new List<Client>
            {
                new Client
                {
                    ClientId = "CatalogClient",

                    AllowedGrantTypes =
                    {
                        GrantType.ClientCredentials,
                        GrantType.ResourceOwnerPassword
                    },

                    ClientSecrets =
                    {
                        new Secret("08c0f7a5-5d48-4041-a2f6-95134be09a94".Sha256())
                    },

                    RedirectUris =
                    {
                        "http://localhost:5242",
                        "http://localhost:8080"
                    },

                    AllowedCorsOrigins =
                    {
                        "http://localhost:5242",
                        "http://localhost:8080"
                    },

                    AllowOfflineAccess = true,

                    AllowedScopes =
                    {
                        "Catalog" ,
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile
                    }
                },

                new Client
                {
                    ClientId = "BasketClient",

                    AllowedGrantTypes =
                    {
                        GrantType.ClientCredentials,
                        GrantType.ResourceOwnerPassword
                    },

                    ClientSecrets =
                    {
                        new Secret("70dc89ef-d09e-4a6d-94ba-bcd66a723e92".Sha256())
                    },

                    AllowedCorsOrigins =
                    {
                        "http://localhost:8090",
                        "http://localhost:5070",
                    },

                    RedirectUris =
                    {
                        "http://localhost:5070",
                        "http://localhost:8090"
                    },

                    AllowOfflineAccess = true,

                    AllowedScopes =
                    {
                        "Basket" ,
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile
                    }
                },
            };
    }
}
