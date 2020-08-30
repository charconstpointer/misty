using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Misty.Domain.Entities;
using Misty.Domain.Repositories;

namespace Misty.Persistence.Repositories
{
    public class AdsRepository : IAdsRepository
    {
        private readonly MistyContext _context;

        public AdsRepository(MistyContext context)
        {
            _context = context;
        }

        public async Task Save(Ad article)
        {
            await _context.Ads.AddAsync(article);
            await _context.SaveChangesAsync();
        }

        public async Task<Ad> Get(int id)
        {
            return await _context.Ads.SingleOrDefaultAsync(a => a.Id == id);
        }

        public async Task<IEnumerable<Ad>> GetAll()
        {
            return await _context.Ads.ToListAsync();
        }

        public async Task Update(int id, Ad article)
        {
            var ad =await  Get(id);
            //TODO Update Ad
        }

        public async Task Delete(int id)
        {
            var ad = await Get(id);
            _context.Ads.Remove(ad);
            await _context.SaveChangesAsync();
        }
    }
}