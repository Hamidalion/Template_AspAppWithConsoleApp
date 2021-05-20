using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using WCA_PL.Model;
using WCA_PL.Services;

namespace WCA_PL
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var hostBuilder = new HostBuilder()
                .ConfigureAppConfiguration(configBuilder =>  // конфигурация хоста
                {
                    configBuilder.AddJsonFile("config.json"); // Сохранение нашего конфига в этом джейсоне
                    configBuilder.AddCommandLine(args); // подключение возможности передачи каких-нибудь аргуметов через командную строку
                })
                .ConfigureLogging(configLogging => // конфигурация логирования
                {
                    configLogging.AddConsole();
                    configLogging.AddDebug();
                })
                .ConfigureServices(services => // конфигурация наших зависимостей
                {
                    services.AddHostedService<TaskSchedulerService>(); 
                    services.AddSingleton<Settings>();
                });

            await hostBuilder.RunConsoleAsync();
        }
    }
}
