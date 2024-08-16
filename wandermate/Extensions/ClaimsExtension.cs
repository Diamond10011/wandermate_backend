using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace wandermate.Extensions
{
    public static class ClaimsExtension
    {
        public static string GetUsername(this ClaimsPrincipal user)
        {
            // return user.Claims.SingleOrDefault(x => x.Type.Equals("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/givenname")).Value;
            var username = user.Claims.SingleOrDefault(x => x.Type == ClaimTypes.GivenName).Value;
            return username;
        }

        public static string GetUserId(this ClaimsPrincipal user)
        {

            var userid = user.Claims.SingleOrDefault(x => x.Type == ClaimTypes.NameIdentifier).Value;

            // Return the claim value if it exists, otherwise return null or an empty string
            return userid;
        }
    }
}