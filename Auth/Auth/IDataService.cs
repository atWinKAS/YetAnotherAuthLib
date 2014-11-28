using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auth
{
    using Auth.Domain;

    public interface IDataService
    {
        IQueryable<User> Users();

        User User(int id);
    }
}
