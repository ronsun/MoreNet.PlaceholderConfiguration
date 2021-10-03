using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;
using MoreNet.PlaceholderConfiguration.Helpers;
using System.IO;

namespace MoreNet.PlaceholderConfiguration
{
    /// <summary>
    /// A JSON file based <see cref="FileConfigurationProvider"/> with placeholder in specific format will replaced by environment variables.
    /// </summary>
    public class PlaceholderJsonConfigurationProvider : JsonConfigurationProvider
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PlaceholderJsonConfigurationProvider"/> class.
        /// </summary>
        /// <param name="source">The <see cref="PlaceholderJsonConfigurationSource"/>.</param>
        public PlaceholderJsonConfigurationProvider(PlaceholderJsonConfigurationSource source)
            : base(source)
        {
        }

        /// <inheritdoc/>
        public override void Load(Stream stream)
        {
            base.Load(stream);
            PlaceholderHelper.ReplaceFromEnvironmentVariables(Data);
        }
    }
}
