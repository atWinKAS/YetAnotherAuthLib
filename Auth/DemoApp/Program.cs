using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoApp
{
    using Auth;

    class Program
    {
        static void Main(string[] args)
        {
            var auth = new Auth.Authenticator(new StubService());
            auth.Authenticate("User1", "p1");

            var app = new MainApp();

            app.ShowInfo();

            app.AllCanDoThis();
            app.AdminsCanDoThis();

            Console.ReadLine();
        }
    }
}
