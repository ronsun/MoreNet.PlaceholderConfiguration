using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using MoreNet.PlaceholderConfiguration.Demo.Configuration;
using System.Linq;

namespace MoreNet.PlaceholderConfiguration.Demo.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HomeController : ControllerBase
    {
        private IOptionsMonitor<ServerInfo> _serverInfo;
        private IConfiguration _config;

        public HomeController(IOptionsMonitor<ServerInfo> serverInfo, IConfiguration config)
        {
            _serverInfo = serverInfo;
            _config = config;
        }

        [HttpGet]
        public string Get()
        {
            return new string[]
            {
                "Server info: " + _serverInfo.CurrentValue.Data,
                "Server info from IConfiguration: " + _config.GetValue<string>("ServerInfo:Data"),
                "Default loging level: " + _config.GetValue<string>("Logging:LogLevel:Default"),
            }
            .Aggregate((left, right) => left + "\r\n" + right);
        }
    }
}
