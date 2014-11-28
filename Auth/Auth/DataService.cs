using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auth
{
    public class DataService : IDataService
    {
        private readonly DataContext dataContext;

        public DataService(DataContext context)
        {
            this.dataContext = context;
        }

        public IQueryable<Domain.User> Users()
        {
            return this.dataContext.Users;
        }

        public Domain.User User(int id)
        {
            return this.dataContext.Users.FirstOrDefault(u => u.Id == id);
        }
    }
}
