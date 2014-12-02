// ***********************************************************************
// Assembly         : Auth
// Author           : Andrii Tkach
// Created          : 02-12-2014
//
// ***********************************************************************
// <copyright file="Authenticator.cs" company="WinKAS A/S">
//     WinKAS A/S. All rights reserved.
// </copyright>
// <summary>
//    Here we try to implement simple authentication features
// </summary>
// ***********************************************************************

namespace Auth
{
    using System;
    using System.Linq;

    using System.Security;
    using System.Security.Claims;

    using System.Threading;

    using Auth.Domain;

    /// <summary>
    /// Authentication manager
    /// </summary>
    public class Authenticator
    {
        /// <summary>
        /// The data service
        /// </summary>
        private IDataService dataService;

        /// <summary>
        /// Initializes a new instance of the <see cref="Authenticator"/> class.
        /// </summary>
        public Authenticator()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Authenticator"/> class.
        /// </summary>
        /// <param name="service">The service.</param>
        public Authenticator(IDataService service)
        {
            this.dataService = service;
        }

        /// <summary>
        /// Gets or sets the service.
        /// </summary>
        /// <value>
        /// The service.
        /// </value>
        public IDataService Service 
        {
            get
            {
                return this.dataService;
            }

            set
            {
                this.dataService = value;
            } 
        }

        /// <summary>
        /// Users the exists.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="pass">The pass.</param>
        /// <returns>True if user exists in the data storage</returns>
        /// <exception cref="System.Exception">Data service has not been initialized</exception>
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

        /// <summary>
        /// Authenticates the specified name.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="pass">The pass.</param>
        /// <returns>Some demo string with authentication result</returns>
        /// <exception cref="System.Exception">Data service has not been initialized</exception>
        /// <exception cref="System.Security.SecurityException">Invalid user name or password</exception>
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

        /// <summary>
        /// Setups the principal.
        /// </summary>
        /// <param name="user">The user.</param>
        private void SetupPrincipal(User user)
        {
            var i = new CorpIdentity(user.Name, "admin");

            var id = new ClaimsIdentity(i.Claims, "DemoAuth");
            var p = new ClaimsPrincipal(id);
            Thread.CurrentPrincipal = p;
        }
    }
}
