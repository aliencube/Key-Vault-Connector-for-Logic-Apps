using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using AutoMapper;

using KeyVaultConnector.FunctionApp.Models;

using Microsoft.Azure.KeyVault.Models;
using Microsoft.Rest.Azure;

namespace KeyVaultConnector.FunctionApp.Extensions
{
    /// <summary>
    /// This represents the extension entity for the <see cref="SecretItem"/> class.
    /// </summary>
    public static class SecretItemExtensions
    {
        /// <summary>
        /// Converts the list of the <see cref="SecretItem"/> instances to the list of the <see cref="SecretItemModel"/> instances.
        /// </summary>
        /// <param name="value">List of the <see cref="SecretItem"/> instances.</param>
        /// <param name="mapper"><see cref="IMapper"/> instance.</param>
        /// <returns>List of the <see cref="SecretItemModel"/> instances.</returns>
        public static async Task<List<SecretItemModel>> MapAsync(this Task<IPage<SecretItem>> value, IMapper mapper)
        {
            var instance = await value.ConfigureAwait(false);
            var items = instance.OfType<SecretItem>().ToList();

            var mapped = mapper.Map<List<SecretItemModel>>(items);

            return mapped;
        }
    }
}