using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Aliencube.AzureFunctions.Extensions.DependencyInjection.Abstractions;

using AutoMapper;

using KeyVaultConnector.FunctionApp.Configurations;
using KeyVaultConnector.FunctionApp.Models;

using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.KeyVault;
using Microsoft.Azure.KeyVault.Models;
using Microsoft.Extensions.Logging;

namespace KeyVaultConnector.FunctionApp.Functions
{
    /// <summary>
    /// This represents the function entity to get secrets from Key Vault.
    /// </summary>
    public class GetSecretsFunction : FunctionBase<ILogger>, IGetSecretsFunction
    {
        private readonly AppSettings _settings;
        private readonly IMapper _mapper;
        private readonly IKeyVaultClient _kv;

        /// <summary>
        /// Initializes a new instance of the <see cref="GetSecretsFunction"/> class.
        /// </summary>
        /// <param name="settings"><see cref="AppSettings"/> instance.</param>
        /// <param name="mapper"><see cref="IMapper"/> instance.</param>
        /// <param name="kv"><see cref="IKeyVaultClient"/> instance.</param>
        public GetSecretsFunction(AppSettings settings, IMapper mapper, IKeyVaultClient kv)
        {
            this._settings = settings ?? throw new ArgumentNullException(nameof(settings));
            this._mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            this._kv = kv ?? throw new ArgumentNullException(nameof(kv));
        }

        /// <inheritdoc />
        public override async Task<TOutput> InvokeAsync<TInput, TOutput>(TInput input, FunctionOptionsBase options = null)
        {
            this.Log.LogInformation("C# HTTP trigger function processed a request.");

            var secrets = await this._kv.GetSecretsAsync(this._settings.KeyVault.BaseUri).ConfigureAwait(false);
            var items = secrets.OfType<SecretItem>().ToList();
            var mapped = this._mapper.Map<List<SecretItemModel>>(items);

            return (TOutput)(IActionResult)new OkObjectResult(mapped);
        }
    }
}