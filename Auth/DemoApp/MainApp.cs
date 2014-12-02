using System;
using System.Collections.Generic;
using System.IdentityModel.Services;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace DemoApp
{
    using System.Threading;

    public class MainApp
    {
        public void ShowInfo()
        {
            Console.WriteLine("-= Current user info =-");

            var p = Thread.CurrentPrincipal;
            Console.WriteLine("Is Authenticated: {0}",  p.Identity.IsAuthenticated);
            Console.WriteLine("User name: {0}", p.Identity.Name);
            Console.WriteLine("Is Admin: {0}", p.IsInRole("admin"));

            Console.WriteLine("-=====================-");
        }

        public void AllCanDoThis()
        {
            Console.WriteLine(Environment.NewLine);
            Console.WriteLine("Any person can invoke this method.");
            Console.WriteLine(Environment.NewLine);
        }

        [ClaimsPrincipalPermission(SecurityAction.Demand, Operation = "Read", Resource = "AdminArea")]
        public void AdminsCanDoThis1()
        {
            Console.WriteLine(Environment.NewLine);
            Console.WriteLine("Only the person with 'admin' role can invoke this method (1).");
            Console.WriteLine(Environment.NewLine);
        }

        public void AdminsCanDoThis2()
        {
            ClaimsPrincipalPermission.CheckAccess("AdminArea", "Read");
            
            Console.WriteLine(Environment.NewLine);
            Console.WriteLine("Only the person with 'admin' role can invoke this method (2).");
            Console.WriteLine(Environment.NewLine);
        }
    }
}
