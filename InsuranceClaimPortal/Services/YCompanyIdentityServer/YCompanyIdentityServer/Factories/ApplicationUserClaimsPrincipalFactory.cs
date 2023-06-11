using IdentityModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using System.Security.Claims;
using YCompanyIdentityServer.Models;

namespace YCompanyIdentityServer.Factories
{
    /// <summary>
    /// ASP.Net Core identity will generate the claims principal using the identity user class. To add these custom claims, we have to create a custom claims factory to add these claims to claims principal. 
    /// it will inherit from userclaimsprincipals factory
    /// </summary>
    public class ApplicationUserClaimsPrincipalFactory : UserClaimsPrincipalFactory<ApplicationUser>
    {
        public ApplicationUserClaimsPrincipalFactory(UserManager<ApplicationUser> userManager, IOptions<IdentityOptions> optionsAccessor) : base(userManager, optionsAccessor)
        {
        }

        protected override async Task<ClaimsIdentity> GenerateClaimsAsync(ApplicationUser user)
        {
            var claimsIdentity = await base.GenerateClaimsAsync(user);
            if (user.GivenName != null)
            {
                claimsIdentity.AddClaim(new Claim(JwtClaimTypes.GivenName, user.GivenName));
            }

            if (user.FamilyName != null)
            {
                claimsIdentity.AddClaim(new Claim(JwtClaimTypes.FamilyName, user.FamilyName));
            }
            return claimsIdentity;
        }
    }
}

