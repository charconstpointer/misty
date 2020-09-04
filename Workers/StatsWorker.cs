using System;
using System.ComponentModel;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using Misty.Persistence;

namespace Misty.Workers
{
    public class StatsWorker : BackgroundService
    {
        private readonly MistyContext _context;

        public StatsWorker(MistyContext context)
        {
            _context = context;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                var popular = await _context.Articles
                    .Take(10)
                    .OrderByDescending(a => a.ContentVisitors.Count())
                    .ToListAsync(cancellationToken: stoppingToken);
                
                await Task.Delay(TimeSpan.FromHours(168), stoppingToken);
            }
        }
    }
}