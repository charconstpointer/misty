using System.Collections.Generic;
using System.Threading.Tasks;

namespace Misty.Domain.Repositories
{
    public interface IRepository<T>
    {
        Task Save(T article);
        Task<T> Get(int id);
        Task<IEnumerable<T>> GetAll();
        Task Update(int id, T article);
        Task Delete(int id);
    }
}