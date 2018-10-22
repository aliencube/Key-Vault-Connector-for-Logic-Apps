using Newtonsoft.Json;

namespace KeyVaultConnector.FunctionApp.Models
{
    /// <summary>
    /// This represents the model entity for secret items used for collection.
    /// </summary>
    public class SecretItemModel : SecretModel
    {
        /// <inheritdoc />
        [JsonIgnore]
        public new string Value { get; set; }

        /// <inheritdoc />
        [JsonIgnore]
        public new string Version { get; set; }
    }
}