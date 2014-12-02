// ***********************************************************************
// Assembly         : DemoApp
// Author           : Andrii Tkach
// Created          : 02-12-2014
//
// ***********************************************************************
// <copyright file="Program.cs" company="WinKAS A/S">
//     WinKAS A/S. All rights reserved.
// </copyright>
// <summary>
//    Demo application main class for making authentication and executing demo methods
// </summary>
// ***********************************************************************

namespace DemoApp
{
    using System;

    using Auth;

    /// <summary>
    /// Main application class
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Mains the specified arguments.
        /// </summary>
        /// <param name="args">The arguments.</param>
        public static void Main(string[] args)
        {
            //// 1.
            //// windows authentication
            //// first of all we can make simple windows authentication to get user profile comverted into claims collection and set identity to the current windows thread
            ////var p = new WindowsPrincipal(WindowsIdentity.GetCurrent());
            ////Thread.CurrentPrincipal = p;
            
            //// 2. transform
            //// second way... we can authenticate and transform claims to add additional info obtained from database for example
            ////Thread.CurrentPrincipal =
            ////    FederatedAuthentication.FederationConfiguration.IdentityConfiguration.ClaimsAuthenticationManager
            ////        .Authenticate("none", p) as IPrincipal;
            
            //// 3. custom auth
            //// finally we can make custom authentication to check user credentials and build claims collection
            var auth = new Authenticator(new StubService());
            auth.Authenticate("User1", "p1");

            //// now we able to start Sustem Under Test where we have few public methods and few methods available to some users
            var app = new MainApp();

            app.ShowInfo();

            app.AllCanDoThis();
            app.AdminsCanDoThis1();
            app.AdminsCanDoThis2();

            Console.ReadLine();
        }
    }
}
