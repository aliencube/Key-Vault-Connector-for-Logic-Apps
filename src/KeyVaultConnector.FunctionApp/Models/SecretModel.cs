using Newtonsoft.Json;

namespace KeyVaultConnector.FunctionApp.Models
{
    /// <summary>
    /// This represents the model entity for secret items used for collection.
    /// </summary>
    public class SecretModel : SecretItemModel
    {
        /// <summary>
        /// Gets or sets the value.
        /// </summary>
        [JsonProperty(Order = 3)]
        public string Value { get; set; }

        /// <summary>
        /// Gets or sets the version.
        /// </summary>
        [JsonProperty(Order = 6)]
        public string Version { get; set; }
    }
}