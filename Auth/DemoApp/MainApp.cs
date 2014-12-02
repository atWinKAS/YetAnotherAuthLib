// ***********************************************************************
// Assembly         : DemoApp
// Author           : Andrii Tkach
// Created          : 02-12-2014
//
// ***********************************************************************
// <copyright file="MainApp.cs" company="WinKAS A/S">
//     WinKAS A/S. All rights reserved.
// </copyright>
// <summary>
//    This class creates simple business system wehere we can few methods with secutity restrictions
// </summary>
// ***********************************************************************

namespace DemoApp
{
    using System;
    using System.IdentityModel.Services;
    using System.Security.Permissions;
    using System.Threading;

    /// <summary>
    /// Main demo class
    /// </summary>
    public class MainApp
    {
        /// <summary>
        /// Shows the information about current user: user name, authenticated state and admin role state
        /// </summary>
        public void ShowInfo()
        {
            Console.WriteLine("-= Current user info =-");

            var p = Thread.CurrentPrincipal;
            Console.WriteLine("Is Authenticated: {0}",  p.Identity.IsAuthenticated);
            Console.WriteLine("User name: {0}", p.Identity.Name);
            Console.WriteLine("Is Admin: {0}", p.IsInRole("admin"));

            Console.WriteLine("-=====================-");
        }

        /// <summary>
        /// Demo method available for all users. No authentication required.
        /// </summary>
        public void AllCanDoThis()
        {
            Console.WriteLine(Environment.NewLine);
            Console.WriteLine("Any person can invoke this method.");
            Console.WriteLine(Environment.NewLine);
        }

        /// <summary>
        /// Demo method with authorization attributes
        /// </summary>
        [ClaimsPrincipalPermission(SecurityAction.Demand, Operation = "Read", Resource = "AdminArea")]
        public void AdminsCanDoThis1()
        {
            Console.WriteLine(Environment.NewLine);
            Console.WriteLine("Only the person with 'admin' role can invoke this method (1).");
            Console.WriteLine(Environment.NewLine);
        }

        /// <summary>
        /// Demo method with direct authorization call
        /// </summary>
        public void AdminsCanDoThis2()
        {
            ClaimsPrincipalPermission.CheckAccess("AdminArea", "Read");
            
            Console.WriteLine(Environment.NewLine);
            Console.WriteLine("Only the person with 'admin' role can invoke this method (2).");
            Console.WriteLine(Environment.NewLine);
        }
    }
}
