using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Misty.Domain.Entities;
using Misty.Domain.Repositories;

namespace Misty.Persistence.Repositories
{
    public class ArticlesRepository : IArticlesRepository
    {
        private readonly MistyContext _context;

        public ArticlesRepository(MistyContext context)
        {
            _context = context;
        }

        public async Task Save(Article article)
        {
            await _context.Articles.AddAsync(article);
            await _context.SaveChangesAsync();
        }

        public async Task<Article> Get(int id)
        {
            var article = await _context.Articles
                .Include(a => a.Ads)
                .Include(a => a.Comments)
                .SingleOrDefaultAsync(a => a.Id == id);
            return article;
        }

        public async Task<IEnumerable<Article>> GetAll()
        {
            return await _context.Articles
                .Include(a => a.Ads)
                .Include(a => a.Comments)
                .ToListAsync();
        }

        public async Task Update(int id, Article article)
        {
            var a = await Get(id);
            //TODO Update article impl
        }

        public async Task Delete(int id)
        {
            var a = await Get(id);
            _context.Articles.Remove(a);
            await _context.SaveChangesAsync();
        }
    }
}