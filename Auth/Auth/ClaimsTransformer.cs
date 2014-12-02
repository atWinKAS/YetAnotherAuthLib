// ***********************************************************************
// Assembly         : Auth
// Author           : Andrii Tkach
// Created          : 02-12-2014
//
// ***********************************************************************
// <copyright file="ClaimsTransformer.cs" company="WinKAS A/S">
//     WinKAS A/S. All rights reserved.
// </copyright>
// <summary>
//    Here we try to transform claims collection and add new claims
// </summary>
// ***********************************************************************

namespace Auth
{
    using System;
    using System.Collections.Generic;
    using System.Security.Claims;

    /// <summary>
    /// Claims Transformer
    /// </summary>
    public class ClaimsTransformer : ClaimsAuthenticationManager
    {
        /// <summary>
        /// When overridden in a derived class, returns a <see cref="T:System.Security.Claims.ClaimsPrincipal" /> object consistent with the requirements of the RP application. The default implementation does not modify the incoming <see cref="T:System.Security.Claims.ClaimsPrincipal" />.
        /// </summary>
        /// <param name="resourceName">The address of the resource that is being requested.</param>
        /// <param name="incomingPrincipal">The claims principal that represents the authenticated user that is attempting to access the resource.</param>
        /// <returns>
        /// A claims principal that contains any modifications necessary for the RP application. The default implementation returns the incoming claims principal unmodified.
        /// </returns>
        /// <exception cref="System.Exception">Name claim is empty</exception>
        public override ClaimsPrincipal Authenticate(string resourceName, ClaimsPrincipal incomingPrincipal)
        {
            var name = incomingPrincipal.Identity.Name;
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new Exception("Name claim is empty");
            }

            return this.CreateNewPrincipal(name);
        }

        /// <summary>
        /// Creates the new principal.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns>New Claims Principal with updated Claims collection</returns>
        private ClaimsPrincipal CreateNewPrincipal(string name)
        {
            //// here we can add any new claims based on some we already have

            var newClaim = "false";

            if (name.Equals("User1"))
            {
                newClaim = "true";
            }

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, name),
                new Claim("http://additionalclaims/somenewclaim/", newClaim)
            };

            return new ClaimsPrincipal(new ClaimsIdentity(claims, "Custom"));
        }
    }
}
