using System.Threading.Tasks;
using Misty.Domain.Entities;

namespace Misty.Domain.Repositories
{
    public interface IUsersRepository
    {
        Task Save(RegisteredUser registeredUser);
        Task<RegisteredUser> Get(int id);
    }
}