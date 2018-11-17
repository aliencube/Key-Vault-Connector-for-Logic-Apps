using Aliencube.AzureFunctions.Extensions.DependencyInjection.Abstractions;

namespace KeyVaultConnector.FunctionApp.Functions.FunctionOptions
{
    /// <summary>
    /// This represents the function option entity for the <see cref="GetSecretFunction"/> class.
    /// </summary>
    public class GetSecretFunctionOptions : FunctionOptionsBase
    {
        /// <summary>
        /// Gets or sets the secret name.
        /// </summary>
        public string SecretName { get; set; }
    }
}