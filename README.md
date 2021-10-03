### What's this
This is an extension to make configuration support placeholder with environment variable.  
The format of placeholder is `${The_Variable}`, and it will replced by value set in environment variable. It support `reloadOnChange` except environment variables.  

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