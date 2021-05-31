# Template_AspAppWithConsoleApp

## Acquaintance ##
This application is designed as a template application for a news site. Used a standard set of technologies for MVC asp.net application. 
The architectural approach in this application is wrong.

##### Purpose #####
Get practice in development MVC asp.net apps.

### Step 1 ###

1.  Create solution cmd:\ dotnet new sln
2.  Create ASP.NET project Console core
3.  Make Main async and Task
4.  Edit project file, add <LangVersion>preview</LangVersion>
5.  Create example of HostBulder
6.  Install packert Microsoft.Hostings
7.  Add in HostBuilder .ConfigureAppConfiguration
8.  Add in .ConfigureAppConfiguration .AddJsonFile("config.json") and using;
9.  Add in .ConfigureAppConfiguration .AddJsonFile("config.json") and using;
10. Add config.json in proj
11. Set setting in config.json ~~~ and add <Content Include="**\*.json" Exclude="bin\**\*; obj\**\*" CopyToOutputDirectory="PreserveNewest" />
12. Add Microsoft.Extensions.Logging NuGet
13. Add Microsoft.Extensions.Logging.Console NuGet
14. Add Microsoft.Extensions.Logging.Debug NuGet
15. In .ConfigureLogging .AddConsole() .AddDebug();
16. Add .ConfigureServices
17. Create TaskSchedulerServices.cs inheritance IHostedServices, IDisposable and implement thei
18. Create Model/Settings/ and set properties from our config.json
19. Add created settings in .ConfigureServices
20. Add logger in our TaskSchedulerService about timer
21. Edit StopAsync() 
22. Edit Dispose() 
23. Add in Start() non-repiter  
24. Add our TaskShedileService in configuration
25. Create in TaskShedileService method DoWork()
26. Create class TaskProcessor  
27. For example add funtion febonatti number in own service as TaskProcessor.cs
28. Finish method DoWork() and add his in ProcessTask()
29. Add TaskProcessor in DI container
30. Create WorkerService who select item in queue and do it
31. Create ExecuteAsync() 
32. Create RunInstance()
33. Add WorkerService in services DI


### Step 2 ###


### Step 3 ###


### Step 4 ###


### Step 5 ###


### Step 6 ###


### End ###
