// ***********************************************************************
// Assembly         : Auth
// Author           : Andrii Tkach
// Created          : 02-12-2014
//
// ***********************************************************************
// <copyright file="DataService.cs" company="WinKAS A/S">
//     WinKAS A/S. All rights reserved.
// </copyright>
// <summary>
//    Data service implementation
// </summary>
// ***********************************************************************

namespace Auth
{
    using System.Linq;

    /// <summary>
    /// Data Service
    /// </summary>
    public class DataService : IDataService
    {
        /// <summary>
        /// The data context
        /// </summary>
        private readonly DataContext dataContext;

        /// <summary>
        /// Initializes a new instance of the <see cref="DataService"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        public DataService(DataContext context)
        {
            this.dataContext = context;
        }

        /// <summary>
        /// All users query collection.
        /// </summary>
        /// <returns>
        /// Users collection
        /// </returns>
        public IQueryable<Domain.User> Users()
        {
            return this.dataContext.Users;
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
            return this.dataContext.Users.FirstOrDefault(u => u.Id == id);
        }
    }
}
