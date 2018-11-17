using Aliencube.AzureFunctions.Extensions.DependencyInjection.Abstractions;

using Microsoft.Extensions.Logging;

namespace KeyVaultConnector.FunctionApp.Functions
{
    /// <summary>
    /// This provides interfaces to the <see cref="GetSecretFunction"/> class.
    /// </summary>
    public interface IGetSecretFunction : IFunction<ILogger>
    {
    }
}