using System.Threading.Tasks;
using Misty.Domain.Entities;

namespace Misty.Domain.Repositories
{
    public interface IUsersRepository
    {
        Task Save(User user);
        Task<User> Get(int id);
    }
}