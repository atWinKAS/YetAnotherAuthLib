using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auth.Config
{
    using System.Data.Entity.ModelConfiguration;

    using Auth.Domain;

    public class UserConfiguration : EntityTypeConfiguration<User>
    {
        public UserConfiguration()
        {
            Property(p => p.Name).HasMaxLength(30).IsRequired();
            Property(p => p.Password).HasMaxLength(100).IsRequired();
        }
    }
}
