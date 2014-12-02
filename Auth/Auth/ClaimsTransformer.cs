using System;
using System.Collections.Generic;
using System.Data.Odbc;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security;
using System.Security.Claims;

namespace Auth
{
    public class ClaimsTransformer : ClaimsAuthenticationManager
    {
        public override ClaimsPrincipal Authenticate(string resourceName, ClaimsPrincipal incomingPrincipal)
        {
            var name = incomingPrincipal.Identity.Name;
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new Exception("Name claim is empty");
            }

            return this.CreateNewPrincipal(name);
        }

        private ClaimsPrincipal CreateNewPrincipal(string name)
        {
            //// here we can add any new claims based on some we already have

            var newClaim = "false";

            if (name.Equals("User1"))
            {
                newClaim = "true";
            }

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, name),
                new Claim("http://additionalclaims/somenewclaim/", newClaim)
            };

            return new ClaimsPrincipal(new ClaimsIdentity(claims, "Custom"));
        }
    }
}
