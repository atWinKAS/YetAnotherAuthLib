// ***********************************************************************
// Assembly         : Auth
// Author           : Andrii Tkach
// Created          : 02-12-2014
//
// ***********************************************************************
// <copyright file="IDataService.cs" company="WinKAS A/S">
//     WinKAS A/S. All rights reserved.
// </copyright>
// <summary>
//    Data service interface
// </summary>
// ***********************************************************************

namespace Auth
{
    using System.Linq;

    using Auth.Domain;

    /// <summary>
    /// Data service for user and user rights 
    /// </summary>
    public interface IDataService
    {
        /// <summary>
        /// All users query collection.
        /// </summary>
        /// <returns>Users collection</returns>
        IQueryable<User> Users();

        /// <summary>
        /// Users the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Single user</returns>
        User User(int id);
    }
}
