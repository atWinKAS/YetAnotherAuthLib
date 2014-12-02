// ***********************************************************************
// Assembly         : Auth
// Author           : Andrii Tkach
// Created          : 02-12-2014
//
// ***********************************************************************
// <copyright file="CorpIdentity.cs" company="WinKAS A/S">
//     WinKAS A/S. All rights reserved.
// </copyright>
// <summary>
//    Improoved Claims Identity class with additional features
// </summary>
// ***********************************************************************

namespace Auth
{
    using System.Security.Claims;

    /// <summary>
    /// Corp Identity
    /// </summary>
    public class CorpIdentity : ClaimsIdentity
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CorpIdentity"/> class.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="role">The role.</param>
        public CorpIdentity(string name, string role)
        {
            this.BuildClaimsCollection(name);
        }

        /// <summary>
        /// Gets the full name.
        /// </summary>
        /// <value>
        /// The full name.
        /// </value>
        public string FullName
        {
            get
            {
                return FindFirst(ClaimTypes.Name).Value;
            }
        }

        /// <summary>
        /// Builds the claims collection.
        /// </summary>
        /// <param name="name">The name.</param>
        private void BuildClaimsCollection(string name)
        {
            this.AddClaim(new Claim(ClaimTypes.Name, name));
            this.AddClaim(new Claim(ClaimTypes.Role, "admin"));
            this.AddClaim(new Claim("http://additionalclaims/somenewclaim/", "true"));
        }
    }
}
