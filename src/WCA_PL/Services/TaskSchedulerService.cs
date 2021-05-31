using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;
using WCA_PL.Model;
using WCA_PL.Services.TaskQue;
using WCA_PL.Workers;

namespace WCA_PL.Services
{
    public class TaskSchedulerService : IHostedService, IDisposable // список наших задач
    {
        private Timer timer;
        private readonly IServiceProvider services;
        private readonly Settings settings;
        private readonly ILogger<TaskSchedulerService> logger;
        private readonly object syncRoot = new object();
        private readonly Random random = new Random();

        public TaskSchedulerService(IServiceProvider services)  // Служба планировщика заданий
        {
            this.services = services;
            this.settings = services.GetRequiredService<Settings>();
            this.logger = services.GetRequiredService<ILogger<TaskSchedulerService>>();
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            //var settings = services.GetRequiredService<IConfiguration>();
            //var interval = settings.GetValue<int>("RunInterval"); не сосвсем красивая запись

            var interval = settings?.RunInterval ?? 0;

            if (interval == 0)
            {
                logger.LogWarning("Interval is not defined in settings. Was set 60 sec interval.");
                interval = 60;
            }

            timer = new Timer(
                (e) => ProcessTask(),           // что делаем
                null,                           // начальное значение
                TimeSpan.Zero,                  // когда
                TimeSpan.FromSeconds(interval));// частота обновления

            return Task.CompletedTask;          // вернем заглушку
        }

        private void ProcessTask()
        {
            if (Monitor.TryEnter(syncRoot)) // Для того чтобы не запускал новую таску пока не выполниться предыдущая
            {
                logger.LogInformation($"Process task started.");

                DoWork();

                logger.LogInformation($"Process task finished.");
                Monitor.Exit(syncRoot);
            }
            else
            {
                logger.LogInformation($"Processing is currently in progress. Skipped.");
            }
        }

        private void DoWork()
        {
            var number = random.Next(20);

            var processor = services.GetRequiredService<TaskProcessor>(); //наша задача

            var queue = services.GetRequiredService<IBackgorundTaskQueue>(); //наша очередь

            queue.QueueBackgorundWorkItem(token =>
            {
                return processor.RunAsync(number, token);
            });
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            timer?.Change(Timeout.Infinite, 0);

            return Task.CompletedTask;          // вернем заглушку
        }

        public void Dispose()
        {
            timer?.Dispose();
        }
    }
}
