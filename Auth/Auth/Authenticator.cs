using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auth
{
    using System.ComponentModel.DataAnnotations;
    using System.Security;

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
            if (this.dataService == null)
            {
                throw new Exception("Data service has not been initialized");
            }

            var user = this.dataService.Users().FirstOrDefault(u => u.Name.Equals(name, StringComparison.CurrentCultureIgnoreCase));
            if (user != null)
            {
                if (user.Password.Equals(pass))
                {
                    return "User is okay";
                }
            }

            throw new SecurityException("Invalid user name or password");
        }
    }
}
