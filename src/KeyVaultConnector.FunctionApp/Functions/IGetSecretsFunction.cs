using Aliencube.AzureFunctions.Extensions.DependencyInjection.Abstractions;

using Microsoft.Extensions.Logging;

namespace KeyVaultConnector.FunctionApp.Functions
{
    /// <summary>
    /// This provides interfaces to the <see cref="GetSecretsFunction"/> class.
    /// </summary>
    public interface IGetSecretsFunction : IFunction<ILogger>
    {
    }
}