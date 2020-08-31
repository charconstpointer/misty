using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Misty.Domain.Entities;
using Misty.Domain.Repositories;

namespace Misty.Persistence.Repositories
{
    public class UsersRepository : IUsersRepository
    {
        private readonly MistyContext _context;

        public UsersRepository(MistyContext context)
        {
            _context = context;
        }

        public async Task Save(RegisteredUser registeredUser)
        {
            await _context.Users.AddAsync(registeredUser);
            await _context.SaveChangesAsync();
        }

        public async Task<RegisteredUser> Get(int id)
        {
            var user = await _context.Users.SingleOrDefaultAsync(u => u.Id == id);
            return user;
        }
    }
}