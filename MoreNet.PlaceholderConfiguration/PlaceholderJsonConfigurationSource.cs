using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;

namespace MoreNet.PlaceholderConfiguration
{
    /// <summary>
    /// Represents a JSON file as an <see cref="IConfigurationSource"/> with placeholder in specific format will replaced by environment variables.
    /// </summary>
    public class PlaceholderJsonConfigurationSource : JsonConfigurationSource
    {
        /// <inheritdoc/>
        public override IConfigurationProvider Build(IConfigurationBuilder builder)
        {
            base.Build(builder);

            return new PlaceholderJsonConfigurationProvider(this);
        }
    }
}
