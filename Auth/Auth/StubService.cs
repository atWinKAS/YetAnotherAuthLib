// ***********************************************************************
// Assembly         : Auth
// Author           : Andrii Tkach
// Created          : 02-12-2014
//
// ***********************************************************************
// <copyright file="StubService.cs" company="WinKAS A/S">
//     WinKAS A/S. All rights reserved.
// </copyright>
// <summary>
//    Stub implementation of very simple data service
// </summary>
// ***********************************************************************

namespace Auth
{
    using System.Collections.Generic;
    using System.Linq;

    using Auth.Domain;

    /// <summary>
    /// Stub data service
    /// </summary>
    public class StubService : IDataService
    {
        /// <summary>
        /// The users collection
        /// </summary>
        private readonly IEnumerable<User> users;

        /// <summary>
        /// Initializes a new instance of the <see cref="StubService"/> class.
        /// </summary>
        public StubService()
        {
            this.users = new List<User>()
            {
                new User { Id = 1, Name = "User1", Password = "p1" },
                new User { Id = 2, Name = "User2", Password = "p2" },
                new User { Id = 3, Name = "User3", Password = "p3" }
            };
        }

        /// <summary>
        /// All users query collection.
        /// </summary>
        /// <returns>
        /// Users collection
        /// </returns>
        public IQueryable<Domain.User> Users()
        {
            return this.users.AsQueryable();
        }

        /// <summary>
        /// Users the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>
        /// Single user
        /// </returns>
        public Domain.User User(int id)
        {
            return this.users.FirstOrDefault(u => u.Id == id);
        }
    }
}
