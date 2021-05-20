# Template_AspAppWithConsoleApp

## Acquaintance ##
This application is designed as a template application for a news site. Used a standard set of technologies for MVC asp.net application. 
The architectural approach in this application is wrong.

##### Purpose #####
Get practice in development MVC asp.net apps.

### Step 1 ###
cmd:\ dotnet new sln

1. Create solution
2. Create ASP.NET project Console core

3. Make Main async and Task
4. Edit project file, add <LangVersion>preview</LangVersion>
5. Create example of HostBulder
6. Install packert Microsoft.Hostings
7. Add in HostBuilder .ConfigureAppConfiguration
8. Add in .ConfigureAppConfiguration .AddJsonFile("config.json") and using;
9. Add in .ConfigureAppConfiguration .AddJsonFile("config.json") and using;
10. Add config.json in proj
11. Set setting in config.json ~~~ and add <Content Include="**\*.json" Exclude="bin\**\*; obj\**\*" CopyToOutputDirectory="PreserveNewest" />
12.Add Microsoft.Extensions.Logging NuGet
13.Add Microsoft.Extensions.Logging.Console NuGet
14.Add Microsoft.Extensions.Logging.Debug NuGet
15.In .ConfigureLogging .AddConsole() .AddDebug();
16.Add .ConfigureServices
17.Create TaskSchedulerServices.cs inheritance IHostedServices, IDisposable

 

### Step 2 ###


### Step 3 ###


### Step 4 ###


### Step 5 ###


### Step 6 ###


### End ###
