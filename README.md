### Introduce
This is designed to offer functionality that replaces placeholders in configuration files with environment variables.
Placeholders follow the format `${The_Variable}`. The solution supports `reloadOnChange` except environment variables.  

### How to use
##### Program.cs
``` csharp
public class Program
{
    public static void Main(string[] args)
    {
        CreateHostBuilder(args).Build().Run();
    }

    public static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)
            .ConfigureWebHostDefaults(webBuilder =>
            {
                webBuilder.UseStartup<Startup>();
            })
            .ConfigureAppConfiguration((hostBuilderContext, configBuilder) =>
            {
                // clear original sources
                configBuilder.Sources.Clear();
                // add json file supports placeholder
                configBuilder.AddPlaceholderJsonFile("appsettings.json", optional: false, reloadOnChange: true);
                // add environment variables
                configBuilder.AddEnvironmentVariables();
            })
        ;
}
```

##### Configure appsettings.json
``` json
{
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft": "Warning",
      "Microsoft.Hosting.Lifetime": "Information"
    }
  },
  "AllowedHosts": "*",
  "ServerInfo": {
    "Data": "Name = ${SERVER_NAME}, IP = ${SERVER_IP}, NotFound = ${NOT_FOUND}, Name = ${SERVER_NAME}"
  }
}
```

##### Environment variables
```
SERVER_NAME=Ron's Server  
SERVER_IP=1.1.1.1  
```

### Demo
[Demo Project](MoreNet.PlaceholderConfiguration.Demo)
