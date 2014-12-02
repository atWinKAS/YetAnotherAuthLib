using System;
using System.Collections.Generic;
using System.IdentityModel.Services;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Security;
using System.Security.Claims;

namespace DemoApp
{
    using Auth;

    class Program
    {
        static void Main(string[] args)
        {
            //// windows authentication
            ////var p = new WindowsPrincipal(WindowsIdentity.GetCurrent());
            ////Thread.CurrentPrincipal = p;
            
            //// transform 
            ////Thread.CurrentPrincipal =
            ////    FederatedAuthentication.FederationConfiguration.IdentityConfiguration.ClaimsAuthenticationManager
            ////        .Authenticate("none", p) as IPrincipal;
            
            var auth = new Auth.Authenticator(new StubService());
            auth.Authenticate("User1", "p1");

            var app = new MainApp();

            app.ShowInfo();

            app.AllCanDoThis();
            app.AdminsCanDoThis1();
            app.AdminsCanDoThis2();

            Console.ReadLine();
        }
    }
}
