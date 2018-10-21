using System;
using System.Linq;
using System.Threading.Tasks;

using Aliencube.AzureFunctions.Extensions.DependencyInjection.Abstractions;

using KeyVaultConnector.FunctionApp.Configurations;

using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.KeyVault;
using Microsoft.Extensions.Logging;

namespace KeyVaultConnector.FunctionApp.Functions
{
    /// <summary>
    /// This provides interfaces to the <see cref="GetSecretsFunction"/> class.
    /// </summary>
    public interface IGetSecretsFunction : IFunction<ILogger>
    {
    }

    /// <summary>
    /// This represents the function entity to get secrets from Key Vault.
    /// </summary>
    public class GetSecretsFunction : FunctionBase<ILogger>, IGetSecretsFunction
    {
        private readonly AppSettings _settings;
        private readonly IKeyVaultClient _kv;

        /// <summary>
        /// Initializes a new instance of the <see cref="GetSecretsFunction"/> class.
        /// </summary>
        /// <param name="settings"><see cref="AppSettings"/> instance.</param>
        /// <param name="kv"><see cref="IKeyVaultClient"/> instance.</param>
        public GetSecretsFunction(AppSettings settings, IKeyVaultClient kv)
        {
            this._settings = settings ?? throw new ArgumentNullException(nameof(settings));
            this._kv = kv ?? throw new ArgumentNullException(nameof(kv));
        }

        /// <inheritdoc />
        public override async Task<TOutput> InvokeAsync<TInput, TOutput>(TInput input, FunctionOptionsBase options = null)
        {
            this.Log.LogInformation("C# HTTP trigger function processed a request.");

            var secrets = await this._kv.GetSecretsAsync(this._settings.KeyVault.BaseUri).ConfigureAwait(false);
            var names = secrets.Select(p => p.Identifier.Name);

            return (TOutput)(IActionResult)new OkObjectResult($"Hello, your secrets are {string.Join(",", names)}");
        }
    }
}