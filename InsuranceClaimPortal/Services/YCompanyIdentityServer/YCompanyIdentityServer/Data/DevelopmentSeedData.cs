using Duende.IdentityServer.EntityFramework.Mappers;
using Duende.IdentityServer.Models;
using YCompanyIdentityServer.Models;
using DuendeEntities = Duende.IdentityServer.EntityFramework.Entities;

namespace YCompanyIdentityServer.Data
{
    public class DevelopmentSeedData
    {
        public static ApplicationUser DefaultUser = new ApplicationUser
        {
            UserName = "amitchawla",
            Email = "acamit84@gmail.com",
            GivenName = "Amit",
            FamilyName = "Chawla"
        };

        public static string DefaultPassword = "Pa55w0rd!";


        /*
         * API Resources
         *
         */
        public static ApiResource ApiResource = new ApiResource
        {
            Name = Guid.NewGuid().ToString(),
            DisplayName = "API",
            Scopes = new List<string>()
                {
                    "https://ycompany.com/api"
                }
        };

        public static ApiResource PaymentsAPIResource = new ApiResource
        {
            Name = "PaymentAPIGuid",//Guid.NewGuid().ToString(),
            DisplayName = "Payments API",
            Scopes = new List<string>()
                {
                    "https://ycompany.com/payments"
                }
        };

        public static ApiResource ThirdPartyAPIResource = new ApiResource
        {
            Name = "ThirdPartyAPIGuid",//Guid.NewGuid().ToString(),
            DisplayName = "ThirdParty API",
            Scopes = new List<string>()
                {
                    "https://ycompany.com/thirdparty"
                }
        };

        public static List<ApiResource> ApiResources = new List<ApiResource>
        {
            ApiResource,
            PaymentsAPIResource,
            ThirdPartyAPIResource
        };


        /*
         * API Scopes
         *
         */
        public static ApiScope ApiScope = new ApiScope()
        {
            Name = "https://ycompany.com/api", // same as above
            DisplayName = "API",
        };

        public static ApiScope PaymentsAPIScope = new ApiScope()
        {
            Name = "https://ycompany.com/payments", // same as above
            DisplayName = "Payments API",
        };

        public static ApiScope ThirdPartyAPIScope = new ApiScope()
        {
            Name = "https://ycompany.com/thirdparty", // same as above
            DisplayName = "ThirdParty API",
        };

        public static List<ApiScope> ApiScopes = new List<ApiScope>() { ApiScope, PaymentsAPIScope, ThirdPartyAPIScope };

        /*
        * Clients
        *
        */
        public static List<Client> Clients = new List<Client> { new Client()
            {
                ClientId = "ConsoleApplicationsGuid",//Guid.NewGuid().ToString(),
                ClientSecrets = new List<Secret> { new Secret("secret".Sha512()) },
                //ClientSecrets = new List<Secret> { new Secret("secret") },
                ClientName = "Console Applications",
                AllowedGrantTypes = GrantTypes.ClientCredentials,
                AllowedScopes = new List<string>() { "https://ycompany.com/payments", "https://ycompany.com/thirdparty" },
                AllowedCorsOrigins = new List<string>() { "https://localhost:7001", "https://localhost:7143" } // api url
            },

            new Client()
            {
                ClientId = "WebApp",
                //ClientId = Guid.NewGuid().ToString(),
                ClientSecrets = new List<Secret> { new Secret("secret".Sha512()) },
                ClientName = "Web Applications",
                AllowedGrantTypes = GrantTypes.Code,
                AllowedScopes = new List<string>() { "https://ycompany.com/api", "openid", "profile", "email", "https://ycompany.com/payments", "https://ycompany.com/thirdparty" },
                RedirectUris = new List<string> { "https://localhost:7002/signin-oidc" }, // redirect back to this URL after login
                PostLogoutRedirectUris = new List<string> { "https://localhost:7002/signout-callback-oidc" }
            },

            new Client()
            {
                ClientId = Guid.NewGuid().ToString(),
                RequireClientSecret = false, // no client secret for public SPA
                ClientName = "Single Page Applications",
                AllowedGrantTypes = GrantTypes.Code,
                AllowedScopes = new List<string>() { "https://ycompany.com/api", "openid", "profile", "email", "https://ycompany.com/payments", "https://ycompany.com/thirdparty" },
                RedirectUris = new List<string> { "https://localhost:7003/authentication/login-callback" },
                PostLogoutRedirectUris = new List<string> { "https://localhost:7003/authentication/logout-callback" },
                AllowedCorsOrigins = new List<string>() { "https://localhost:7003" }
            }
        };

        public static List<DuendeEntities.Client> ClientEntities = Clients.Select(x => x.ToEntity()).ToList();

        /*
         * Identity Resources
         *
         */
        public static List<IdentityResource> IdentityResources = new List<IdentityResource>
        {
            new IdentityResources.OpenId(),
            new IdentityResources.Profile(),
            new IdentityResources.Email()
        };

        public static List<DuendeEntities.IdentityResource> IdentityResourceEntities = IdentityResources.Select(x => x.ToEntity()).ToList();
    }
}
