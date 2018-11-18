using Aliencube.AzureFunctions.Extensions.DependencyInjection;

using Microsoft.Extensions.Configuration;

namespace KeyVaultConnector.FunctionApp.Configurations
{
    /// <summary>
    /// This represents the app settings entity.
    /// </summary>
    public class AppSettings
    {
        private const string KeyVaultSettingsKey = "KeyVault";
        private const string SwaggerSettingsKey = "Swagger";

        public AppSettings()
        {
            var config = new ConfigurationBuilder()
                             .AddEnvironmentVariables()
                             .Build();

            this.KeyVault = config.Get<KeyVaultSettings>(KeyVaultSettingsKey);
            this.Swagger = config.Get<SwaggerSettings>(SwaggerSettingsKey);
        }

        /// <summary>
        /// Gets the <see cref="KeyVaultSettings"/> instance.
        /// </summary>
        public virtual KeyVaultSettings KeyVault { get; }

        /// <summary>
        /// Gets the <see cref="SwaggerSettings"/> instance.
        /// </summary>
        public virtual SwaggerSettings Swagger { get; }
    }
}
