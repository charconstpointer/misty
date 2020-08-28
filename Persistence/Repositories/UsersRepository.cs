using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Misty.Domain.Entities;
using Misty.Domain.Repositories;

namespace Misty.Persistence.Repositories
{
    public class UsersRepository : IUsersRepository
    {
        private readonly ICollection<User> _users;

        public UsersRepository(ICollection<User> users)
        {
            _users = users;
        }

        public async Task Save(User user)
        {
            _users.Add(user);
        }

        public async Task<User> Get(int id)
        {
            var user = _users.SingleOrDefault(u => u.Id == id);
            return user;
        }
    }
}