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
                new("PollSystemAPI", "Web API")
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
                    //Страница с подтверждениями прав доступа
                    RequireConsent = false,
                    // Включить в Id Token клаимы с токена доступа
                    // Второй способ на клиенте получить через config.GetClaimsFromUserInfoEndpoint
                    AlwaysIncludeUserClaimsInIdToken = true,
                    RedirectUris =
                    {
                        "http://127.0.0.1:23920/"
                    },
                    AllowedCorsOrigins =
                    {
                        "http://localhost"
                    },
                    AllowedScopes =
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        "PollSystemAPI"
                    },
                    AllowAccessTokensViaBrowser = true,
                    AccessTokenLifetime = 3600,
                    // Для Refresh Token
                    AllowOfflineAccess = true
                }
            };
    }
}
