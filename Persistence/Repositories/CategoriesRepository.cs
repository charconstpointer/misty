using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Misty.Domain.Entities;
using Misty.Domain.Repositories;

namespace Misty.Persistence.Repositories
{
    public class CategoriesRepository : ICategoriesRepository
    {
        private readonly MistyContext _context;

        public CategoriesRepository(MistyContext context)
        {
            _context = context;
        }

        public async Task Save(Category article)
        {
            await _context.Categories.AddAsync(article);
            await _context.SaveChangesAsync();
        }

        public async Task<Category> Get(int id)
        {
            return await _context.Categories.SingleOrDefaultAsync(c => c.Id == id);
        }

        public async Task<IEnumerable<Category>> GetAll()
        {
            return await _context.Categories.ToListAsync();
        }

        public async Task Update(int id, Category article)
        {
            var category = await Get(id);
            //TODO update category
        }

        public async Task Delete(int id)
        {
            var category = await Get(id);
            _context.Categories.Remove(category);
            await _context.SaveChangesAsync();
        }
    }
}