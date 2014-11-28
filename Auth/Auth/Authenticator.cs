using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auth
{
    using System.ComponentModel.DataAnnotations;
    using System.Security;
    using System.Security.Claims;

    using Auth.Domain;
    using System.Threading;

    public class Authenticator
    {
        private IDataService dataService;

        public Authenticator()
        {
        }

        public Authenticator(IDataService service)
        {
            this.dataService = service;
        }

        public IDataService Service {
            get
            {
                return this.dataService;
            }
            set
            {
                this.dataService = value;
            } 
        }
        
        public bool UserExists(string name, string pass)
        {
            if (this.dataService == null)
            {
                throw new Exception("Data service has not been initialized");
            }

            bool result = false;

            var user = this.dataService.Users().FirstOrDefault(u => u.Name.Equals(name, StringComparison.CurrentCultureIgnoreCase));
            if (user != null)
            {
                if (user.Password.Equals(pass))
                {
                    result = true;
                }
            }

            return result;
        }

        public string Authenticate(string name, string pass)
        {
            string result = string.Empty;

            if (this.dataService == null)
            {
                throw new Exception("Data service has not been initialized");
            }

            var user = this.dataService.Users().FirstOrDefault(u => u.Name.Equals(name, StringComparison.CurrentCultureIgnoreCase));
            if (user != null)
            {
                if (user.Password.Equals(pass))
                {
                    result = "User is okay";
                }
            }
            else
            {
                throw new SecurityException("Invalid user name or password");
            }

            this.SetupPrincipal(user);
            return result;
        }

        private void SetupPrincipal(User user)
        {
            var i = new CorpIdentity(user.Name, "admin");

            var id = new ClaimsIdentity(i.Claims, "DemoAuth");
            var p = new ClaimsPrincipal(id);
            Thread.CurrentPrincipal = p;
        }
    }
}
