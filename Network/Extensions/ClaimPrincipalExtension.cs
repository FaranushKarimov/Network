using Domain.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Network.Extensions
{
    //public class ClaimsPrincipalFactory : UserClaimsPrincipalFactory<User>
    //{
    //    public ClaimsPrincipalFactory(UserManager<User> userManager,
    //        IOptions<IdentityOptions> optionsAccessor)
    //        : base(userManager, optionsAccessor)
    //    {
    //    }

    //    protected override async Task<ClaimsIdentity> GenerateClaimsAsync(User user)
    //    {
    //        var claimsIdentity = await base.GenerateClaimsAsync(user);

    //        return claimsIdentity;
    //    }
    //}
    public static class ClaimsPrincipalExtensions
    {
        public static string GetUserId(this ClaimsPrincipal principal)
        {
            return principal.FindFirstValue(ClaimTypes.NameIdentifier);
        }
    }

}
