using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;

namespace Misty.Workers
{
    public class BackupWorker : BackgroundService
    {
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                //Do backup
                await Task.Delay(TimeSpan.FromHours(24), stoppingToken);
            }
        }
    }
}