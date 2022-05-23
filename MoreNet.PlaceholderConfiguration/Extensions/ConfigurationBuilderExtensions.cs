using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.FileProviders;
using System;

namespace MoreNet.PlaceholderConfiguration.Extensions
{
    /// <summary>
    /// Extensinos for <see cref="ConfigurationBuilderExtensions"/>.
    /// </summary>
    public static class ConfigurationBuilderExtensions
    {
        /// <summary>
        /// Adds the JSON configuration provider to builder.
        /// </summary>
        /// <param name="builder">The Microsoft.Extensions.Configuration.IConfigurationBuilder to add to.</param>
        /// <param name="path">Path relative to the base path stored in <see cref="IConfigurationBuilder.Properties"/> of builder.</param>
        /// <param name="optional">Whether the file is optional.</param>
        /// <param name="reloadOnChange">Whether the configuration should be reloaded if the file changes.</param>
        /// <param name="provider">The <see cref="IFileProvider"/> to use to access the file.</param>
        /// <returns>The <see cref="IConfigurationBuilder"/>.</returns>
        public static IConfigurationBuilder AddPlaceholderJsonFile(
            this IConfigurationBuilder builder,
            string path,
            bool optional = false,
            bool reloadOnChange = false,
            IFileProvider provider = null)
        {
            if (builder == null)
            {
                throw new ArgumentNullException(nameof(builder));
            }

            if (string.IsNullOrEmpty(path))
            {
                throw new ArgumentException("File path must be a non-empty string.", nameof(path));
            }

            return builder.AddPlaceholderJsonFile(s =>
            {
                s.FileProvider = provider;
                s.Path = path;
                s.Optional = optional;
                s.ReloadOnChange = reloadOnChange;
                s.ResolveFileProvider();
            });
        }

        /// <summary>
        /// Adds a new <see cref="PlaceholderJsonConfigurationSource"/>.
        /// </summary>
        /// <param name="builder">The <see cref="IConfigurationBuilder"/> to add to.</param>
        /// <param name="configureSource">Configures the source secrets.</param>
        /// <returns>The <see cref="IConfigurationBuilder"/>.</returns>
        public static IConfigurationBuilder AddPlaceholderJsonFile(this IConfigurationBuilder builder, Action<PlaceholderJsonConfigurationSource> configureSource)
            => builder.Add(configureSource);
    }
}