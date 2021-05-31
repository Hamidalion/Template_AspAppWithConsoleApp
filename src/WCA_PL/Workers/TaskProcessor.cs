using Microsoft.Extensions.Logging;
using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WCA_PL.Model;

namespace WCA_PL.Workers
{
    public class TaskProcessor
    {
        private readonly ILogger<TaskProcessor> logger;
        private readonly Settings settings;

        public TaskProcessor(ILogger<TaskProcessor> logger, Settings settings)
        {
            this.logger = logger;
            this.settings = settings;
        }

        public async Task RunAsync(int number, CancellationToken token)
        {
            token.ThrowIfCancellationRequested();

            Func<int, int> fibonacci = null;

            fibonacci = (number) =>
            {
                if (number < 2) return 1;
                else return fibonacci(number - 1) + fibonacci(number - 2);
            };

            var result = await Task.Run(async () =>
           {
               await Task.Delay(1000);
               return Enumerable.Range(0, number).Select(n => fibonacci(n));
           }, token);

            using (var writer = new StreamWriter(settings.ResultPath, true, Encoding.UTF8))
            {
                writer.WriteLine(DateTime.Now.ToString() + " : " + string.Join(" ", result));
            }

            logger.LogInformation($"Task finished. Result: {string.Join(" ", result)} ");
        }
    }
}
