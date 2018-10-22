using System;
using System.Threading.Tasks;

using Aliencube.AzureFunctions.Extensions.DependencyInjection.Abstractions;

using KeyVaultConnector.FunctionApp.Configurations;
using KeyVaultConnector.FunctionApp.Functions.FunctionOptions;

using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.KeyVault;
using Microsoft.Extensions.Logging;

namespace KeyVaultConnector.FunctionApp.Functions
{
    /// <summary>
    /// This represents the function entity to get secret from Key Vault.
    /// </summary>
    public class GetSecretFunction : FunctionBase<ILogger>, IGetSecretFunction
    {
        private readonly AppSettings _settings;
        private readonly IKeyVaultClient _kv;

        /// <summary>
        /// Initializes a new instance of the <see cref="GetSecretFunction"/> class.
        /// </summary>
        /// <param name="settings"><see cref="AppSettings"/> instance.</param>
        /// <param name="kv"><see cref="IKeyVaultClient"/> instance.</param>
        public GetSecretFunction(AppSettings settings, IKeyVaultClient kv)
        {
            this._settings = settings ?? throw new ArgumentNullException(nameof(settings));
            this._kv = kv ?? throw new ArgumentNullException(nameof(kv));
        }

        /// <inheritdoc />
        public override async Task<TOutput> InvokeAsync<TInput, TOutput>(TInput input, FunctionOptionsBase options = null)
        {
            this.Log.LogInformation("C# HTTP trigger function processed a request.");

            var opt = options as GetSecretFunctionOptions ?? throw new ArgumentNullException(nameof(options));

            var secret = await this._kv.GetSecretAsync(this._settings.KeyVault.BaseUri, opt.SecretName).ConfigureAwait(false);

            return (TOutput)(IActionResult)new OkObjectResult(secret);
        }
    }
}