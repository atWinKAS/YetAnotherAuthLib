// ***********************************************************************
// Assembly         : Auth
// Author           : Andrii Tkach
// Created          : 02-12-2014
//
// ***********************************************************************
// <copyright file="AuthorizationManager.cs" company="WinKAS A/S">
//     WinKAS A/S. All rights reserved.
// </copyright>
// <summary>
//    Here we try to implement authorization features based on what we know from the executing context
// </summary>
// ***********************************************************************

namespace Auth
{
    using System.Linq;
    using System.Security.Claims;

    /// <summary>
    /// Authorization Manager
    /// </summary>
    public class AuthorizationManager : ClaimsAuthorizationManager
    {
        /// <summary>
        /// When implemented in a derived class, checks authorization for the subject in the specified context to perform the specified action on the specified resource.
        /// </summary>
        /// <param name="context">The authorization context that contains the subject, resource, and action for which authorization is to be checked.</param>
        /// <returns>
        /// true if the subject is authorized to perform the specified action on the specified resource; otherwise, false.
        /// </returns>
        public override bool CheckAccess(AuthorizationContext context)
        {
            var resource = context.Resource.First().Value;
            var action = context.Action.First().Value;

            if (action.Equals("Read") && resource.Equals("AdminArea"))
            {
                var hasRight = context.Principal.HasClaim("http://additionalclaims/somenewclaim/", "true");
                return hasRight;
            }

            return false;
        }
    }
}
