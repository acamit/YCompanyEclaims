using Microsoft.AspNetCore.Identity;
namespace YCompanyIdentityServer.Models
{
    /// <summary>
    /// ASP.Net Core identity will generate the claims principal using the identity user class. To add these custom claims, we have to create a custom claims factory to add these claims to claims principal. 
    /// </summary>
    public class ApplicationUser : IdentityUser
    {
        public string? GivenName { get; set; }

        public string? FamilyName { get; set; }
    }
}
