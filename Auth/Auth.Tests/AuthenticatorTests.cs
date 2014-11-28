using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auth.Tests
{
    using NUnit.Framework;

    [TestFixture]
    public class AuthenticatorTests
    {
        [Test]
        public void Authenticate_ExistingUser_UserHasAuthenticated()
        {
            var ar = new Authenticator(new StubService());
            string result = ar.Authenticate("User1", "p1");
            Assert.IsNotNullOrEmpty(result, "Empty string response after authentication method.");
            Console.WriteLine(result);
        }
    }
}
