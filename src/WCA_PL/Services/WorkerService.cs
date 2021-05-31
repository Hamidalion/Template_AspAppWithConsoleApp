using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using WCA_PL.Model;
using WCA_PL.Services.TaskQue;

namespace WCA_PL.Services
{
    public class WorkerService : BackgroundService // длительная операция 
    {
        private readonly IBackgorundTaskQueue taskQueue;
        private readonly ILogger<WorkerService> logger;
        private readonly Settings settings;

        public WorkerService(IBackgorundTaskQueue taskQueue, ILogger<WorkerService> logger, Settings settings)
        {
            this.taskQueue = taskQueue;
            this.logger = logger;
            this.settings = settings;
        }

        protected override async Task ExecuteAsync(CancellationToken token)
        {
            var workerCount = settings.WorkersCount;

            var workers = Enumerable.Range(0, workerCount).Select(num => RunInstance(num, token));

            await Task.WhenAll(workers); // запустит все воркеры 
        }

        private async Task RunInstance(int num, CancellationToken token)
        {
            logger.LogInformation($"# {num} is starting.");

            while (!token.IsCancellationRequested)
            {
                var workItem = await taskQueue.DeQueueAsync(token);

                try
                {
                    logger.LogInformation($"# {num}: Processing task. Queue size: {taskQueue.Size}.");
                    await workItem(token);
                }
                catch (Exception ex)
                {
                    logger.LogInformation($"{num}: Error occurred executing task.");
                }
            }

            logger.LogInformation($"# {num} is stopping.");
        }
    }
}
