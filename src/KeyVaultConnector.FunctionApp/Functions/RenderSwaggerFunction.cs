using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

using Aliencube.AzureFunctions.Extensions.DependencyInjection.Abstractions;

using KeyVaultConnector.FunctionApp.Configurations;
using KeyVaultConnector.FunctionApp.Functions.FunctionOptions;
using KeyVaultConnector.FunctionApp.Models;

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

using YamlDotNet.Serialization;

namespace KeyVaultConnector.FunctionApp.Functions
{
    /// <summary>
    /// This represents the function entity to get secret from Key Vault.
    /// </summary>
    public class RenderSwaggerFunction : FunctionBase<ILogger>, IRenderSwaggerFunction
    {
        private readonly AppSettings _settings;
        private readonly HttpClient _http;

        /// <summary>
        /// Initializes a new instance of the <see cref="RenderSwaggerFunction"/> class.
        /// </summary>
        /// <param name="settings"><see cref="AppSettings"/> instance.</param>
        /// <param name="http"><see cref="HttpClient"/> instance.</param>
        public RenderSwaggerFunction(AppSettings settings, HttpClient http)
        {
            this._settings = settings ?? throw new ArgumentNullException(nameof(settings));
            this._http = http ?? throw new ArgumentNullException(nameof(http));
        }

        /// <inheritdoc />
        public override async Task<TOutput> InvokeAsync<TInput, TOutput>(TInput input, FunctionOptionsBase options = null)
        {
            this.Log.LogInformation("C# HTTP trigger function processed a request.");

            var opt = options as RenderSwaggerFunctionOptions ?? throw new ArgumentNullException(nameof(options));

            if (!IsValidSwaggerExtension(opt.Extension))
            {
                var statusCode = (int)HttpStatusCode.BadRequest;
                var value = new ErrorModel(statusCode, "Extension not supported");

                return (TOutput)(IActionResult)new ObjectResult(value) { StatusCode = statusCode };
            }

            var swagger = await this._http.GetStringAsync(this._settings.Swagger.ImportUrl)
                                          .ConfigureAwait(false);

            if (IsYaml(opt.Extension))
            {
                return (TOutput)(IActionResult)new OkObjectResult(swagger);
            }

            if (IsJson(opt.Extension))
            {
                var deserialiser = new DeserializerBuilder().Build();
                var deserialised = deserialiser.Deserialize<dynamic>(swagger);

                return (TOutput)(IActionResult)new OkObjectResult(deserialised);
            }

            throw new InvalidOperationException();
        }

        private static bool IsJson(string extension)
        {
            if (extension.Equals("json", StringComparison.CurrentCultureIgnoreCase))
            {
                return true;
            }

            return false;
        }

        private static bool IsYaml(string extension)
        {
            if (extension.Equals("yaml", StringComparison.CurrentCultureIgnoreCase))
            {
                return true;
            }

            return false;
        }

        private static bool IsValidSwaggerExtension(string extension)
        {
            if (IsJson(extension))
            {
                return true;
            }

            if (IsYaml(extension))
            {
                return true;
            }

            return false;
        }
    }
}