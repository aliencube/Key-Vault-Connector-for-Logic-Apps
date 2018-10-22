using System;
using System.Net;
using System.Threading.Tasks;

using Aliencube.AzureFunctions.Extensions.DependencyInjection;
using Aliencube.AzureFunctions.Extensions.DependencyInjection.Abstractions;

using KeyVaultConnector.FunctionApp.Functions;
using KeyVaultConnector.FunctionApp.Functions.FunctionOptions;
using KeyVaultConnector.FunctionApp.Modules;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;

namespace KeyVaultConnector.FunctionApp
{
    /// <summary>
    /// This represents the HTTP trigger entity for Key Vault secrets.
    /// </summary>
    public static class SecretsHttpTrigger
    {
        /// <summary>
        /// Gets the <see cref="IFunctionFactory"/> instance.
        /// </summary>
        public static IFunctionFactory Factory = new FunctionFactory<AppModule>();

        /// <summary>
        /// Invokes the function endpoint to get the list of secrets.
        /// </summary>
        /// <param name="req"><see cref="HttpRequest"/> instance.</param>
        /// <param name="log"><see cref="ILogger"/> instance.</param>
        /// <returns>Returns the <see cref="IActionResult"/> containing the list of secret names.</returns>
        [FunctionName(nameof(GetSecrets))]
        public static async Task<IActionResult> GetSecrets(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = "secrets")] HttpRequest req,
            ILogger log)
        {
            IActionResult result;
            try
            {
                result = await Factory.Create<IGetSecretsFunction, ILogger>(log)
                                      .InvokeAsync<HttpRequest, IActionResult>(req)
                                      .ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                var statusCode = (int)HttpStatusCode.InternalServerError;
                var value = new { statusCode = statusCode, message = ex.Message };
                result = new ObjectResult(value) { StatusCode = statusCode };
            }

            return result;
        }

        /// <summary>
        /// Invokes the function endpoint to get the secret.
        /// </summary>
        /// <param name="req"><see cref="HttpRequest"/> instance.</param>
        /// <param name="name">Secret name.</param>
        /// <param name="log"><see cref="ILogger"/> instance.</param>
        /// <returns>Returns the <see cref="IActionResult"/> containing the list of secret names.</returns>
        [FunctionName(nameof(GetSecret))]
        public static async Task<IActionResult> GetSecret(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = "secrets/{name}")] HttpRequest req,
            string name,
            ILogger log)
        {
            IActionResult result;
            try
            {
                var options = new GetSecretFunctionOptions() { SecretName = name };

                result = await Factory.Create<IGetSecretFunction, ILogger>(log)
                                      .InvokeAsync<HttpRequest, IActionResult>(req, options)
                                      .ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                var statusCode = (int)HttpStatusCode.InternalServerError;
                var value = new { statusCode = statusCode, message = ex.Message };
                result = new ObjectResult(value) { StatusCode = statusCode };
            }

            return result;
        }
    }
}