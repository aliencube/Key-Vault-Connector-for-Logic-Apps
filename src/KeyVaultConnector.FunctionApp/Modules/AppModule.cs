using Aliencube.AzureFunctions.Extensions.DependencyInjection.Abstractions;

using KeyVaultConnector.FunctionApp.Configurations;
using KeyVaultConnector.FunctionApp.Functions;

using Microsoft.Azure.KeyVault;
using Microsoft.Azure.Services.AppAuthentication;
using Microsoft.Extensions.DependencyInjection;

namespace KeyVaultConnector.FunctionApp.Modules
{
    /// <summary>
    /// This represents the module entity for the IoC container.
    /// </summary>
    public class AppModule : Module
    {
        /// <inheritdoc />
        public override void Load(IServiceCollection services)
        {
            var azureServiceTokenProvider = new AzureServiceTokenProvider();
            var kv = new KeyVaultClient(new KeyVaultClient.AuthenticationCallback(azureServiceTokenProvider.KeyVaultTokenCallback));

            services.AddSingleton<IKeyVaultClient>(kv);
            services.AddSingleton<AppSettings>(new AppSettings());

            services.AddTransient<IGetSecretsFunction, GetSecretsFunction>();
        }
    }
}