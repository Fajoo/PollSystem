using IdentityServer4;
using IdentityServer4.Models;
using IdentityModel;

namespace Auth.Identity
{
    public static class Configuration
    {
        public static IEnumerable<ApiScope> ApiScopes =>
            new List<ApiScope>
            {
                new("PollSystemAPI", "Web API"),
                new("PollSystem.SignalR", "SignalR")
            };

        public static IEnumerable<IdentityResource> IdentityResources =>
            new List<IdentityResource>
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile()
            };

        public static IEnumerable<ApiResource> ApiResources =>
            new List<ApiResource>
            {
                new("PollSystemAPI", "Web API", new []
                    { JwtClaimTypes.Name})
                {
                    Scopes = { "PollSystemAPI" }
                },
                new("PollSystem.SignalR", "SignalR", new []
                    { JwtClaimTypes.Name})
                {
                    Scopes = { "PollSystem.SignalR" }
                }
            };

        public static IEnumerable<Client> Clients =>
            new List<Client>
            {
                new()
                {
                    ClientId = "wpf-app",
                    ClientName = "Auth Web",
                    AllowedGrantTypes = GrantTypes.Code,
                    RequireClientSecret = false,
                    RequirePkce = true,
                    RequireConsent = false,
                    AlwaysIncludeUserClaimsInIdToken = true,
                    RedirectUris =
                    {
                        "http://127.0.0.1/sample-wpf-app"
                    },
                    AllowedCorsOrigins =
                    {
                        "http://localhost"
                    },
                    AllowedScopes =
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        "PollSystemAPI",
                        "PollSystem.SignalR"
                    },
                    AbsoluteRefreshTokenLifetime = 10,
                    AllowAccessTokensViaBrowser = true,
                    AccessTokenLifetime = 3600,
                    AllowOfflineAccess = true
                }
            };
    }
}
