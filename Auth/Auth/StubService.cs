using Auth.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auth
{
    public class StubService : IDataService
    {
        private readonly IEnumerable<User> users;

        public StubService()
        {
            this.users = new List<User>()
            {
                new User { Id = 1, Name = "User1", Password = "p1" },
                new User { Id = 2, Name = "User2", Password = "p2" },
                new User { Id = 3, Name = "User3", Password = "p3" }
            };
        }

        public IQueryable<Domain.User> Users()
        {
            return this.users.AsQueryable();
        }

        public Domain.User User(int id)
        {
            return this.users.FirstOrDefault(u => u.Id == id);
        }
    }
}
