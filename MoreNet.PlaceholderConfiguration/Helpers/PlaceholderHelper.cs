using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace MoreNet.PlaceholderConfiguration.Helpers
{
    /// <summary>
    /// Helpers for placeholder.
    /// </summary>
    internal static class PlaceholderHelper
    {
        /// <summary>
        /// Replace values in <paramref name="data"/> by environment variables.
        /// </summary>
        /// <param name="data">The imported configuration.</param>
        internal static void ReplaceFromEnvironmentVariables(IDictionary<string, string> data)
        {
            // ex: the_key = "myValue"
            var environmentVariables = Environment.GetEnvironmentVariables();
            var placeholderRegex = new Regex(@"(?<=\$\{)([a-zA-Z0-9_]+)(?=\})");

            var availableDataItems = data.Where(kv => placeholderRegex.IsMatch(kv.Value ?? string.Empty)).ToList();

            // ex: key:value => "Root:Section:Leaf":"${the_key} and ${another_key}"
            foreach (var dataItem in availableDataItems)
            {
                var allKeys = placeholderRegex.Matches(dataItem.Value ?? string.Empty).Select(r => r.Value).Distinct();

                // ex: "the_key"
                foreach (var key in allKeys)
                {
                    if (environmentVariables.Contains(key))
                    {
                        // ex: myValue
                        var realValue = $"{environmentVariables[key]}";
                        var placeholder = "${" + key + "}";
                        data[dataItem.Key] = data[dataItem.Key].Replace(placeholder, realValue);
                    }
                }
            }
        }
    }
}
