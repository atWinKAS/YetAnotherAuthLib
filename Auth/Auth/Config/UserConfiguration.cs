// ***********************************************************************
// Assembly         : Auth
// Author           : Andrii Tkach
// Created          : 02-12-2014
//
// ***********************************************************************
// <copyright file="UserConfiguration.cs" company="WinKAS A/S">
//     WinKAS A/S. All rights reserved.
// </copyright>
// <summary>
//    Entity framework configuration class
// </summary>
// ***********************************************************************

namespace Auth.Config
{
    using System.Data.Entity.ModelConfiguration;

    using Auth.Domain;

    /// <summary>
    /// User Configuration
    /// </summary>
    public class UserConfiguration : EntityTypeConfiguration<User>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UserConfiguration"/> class.
        /// </summary>
        public UserConfiguration()
        {
            Property(p => p.Name).HasMaxLength(30).IsRequired();
            Property(p => p.Password).HasMaxLength(100).IsRequired();
        }
    }
}
