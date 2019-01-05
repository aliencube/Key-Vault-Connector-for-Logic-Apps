using System.Threading.Tasks;

using AutoMapper;

using KeyVaultConnector.FunctionApp.Models;

using Microsoft.Azure.KeyVault.Models;

namespace KeyVaultConnector.FunctionApp.Extensions
{
    /// <summary>
    /// This represents the extension entity for the <see cref="SecretBundle"/> class.
    /// </summary>
    public static class SecretBundleExtensions
    {
        /// <summary>
        /// Converts the <see cref="SecretBundle"/> instance to the <see cref="SecretModel"/> instance.
        /// </summary>
        /// <param name="value"><see cref="SecretBundle"/> instance.</param>
        /// <param name="mapper"><see cref="IMapper"/> instance.</param>
        /// <returns><see cref="SecretModel"/> instance.</returns>
        public static async Task<SecretModel> MapAsync(this Task<SecretBundle> value, IMapper mapper)
        {
            var instance = await value.ConfigureAwait(false);

            var mapped = mapper.Map<SecretModel>(instance);

            return mapped;
        }
    }
}