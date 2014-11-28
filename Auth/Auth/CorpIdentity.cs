using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auth
{
    using System.Security.Claims;

    public class CorpIdentity : ClaimsIdentity
    {
        public CorpIdentity(string name, string role)
        {
            this.AddClaim(new Claim(ClaimTypes.Name, name));
            this.AddClaim(new Claim(ClaimTypes.Role, "admin"));
        }

        public string Name
        {
            get
            {
                return FindFirst(ClaimTypes.Name).Value;
            }
        }
    }
}
