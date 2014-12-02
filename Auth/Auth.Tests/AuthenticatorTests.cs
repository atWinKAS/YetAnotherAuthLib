// ***********************************************************************
// Assembly         : Auth.Tests
// Author           : Andrii Tkach
// Created          : 02-12-2014
//
// ***********************************************************************
// <copyright file="AuthenticatorTests.cs" company="WinKAS A/S">
//     WinKAS A/S. All rights reserved.
// </copyright>
// <summary>
//    Tests for Auth library
// </summary>
// ***********************************************************************

namespace Auth.Tests
{
    using System;

    using NUnit.Framework;

    /// <summary>
    /// Authenticator Tests
    /// </summary>
    [TestFixture]
    public class AuthenticatorTests
    {
        /// <summary>
        /// Authentication call with user name and password.
        /// </summary>
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
