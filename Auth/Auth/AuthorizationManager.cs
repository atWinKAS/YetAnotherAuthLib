using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Auth
{
    public class AuthorizationManager : ClaimsAuthorizationManager
    {
        public override bool CheckAccess(AuthorizationContext context)
        {
            var resource = context.Resource.First().Value;
            var action = context.Action.First().Value;

            if (action.Equals("Read") && resource.Equals("AdminArea"))
            {
                var hasRight = context.Principal.HasClaim("http://additionalclaims/somenewclaim/", "true");
                return hasRight;
            }

            return false;
        }
    }
}
