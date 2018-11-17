using System;

using Newtonsoft.Json;

namespace KeyVaultConnector.FunctionApp.Models
{
    /// <summary>
    /// This represents the model entity for secret.
    /// </summary>
    public class SecretItemModel
    {
        /// <summary>
        /// Gets or sets the Id.
        /// </summary>
        [JsonProperty(Order = 1)]
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        [JsonProperty(Order = 2)]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the value indicating whether the secret is enabled or not.
        /// </summary>
        [JsonProperty(Order = 4)]
        public bool Enabled { get; set; }

        /// <summary>
        /// Gets or sets the value indicating whether the secret is managed or not.
        /// </summary>
        [JsonProperty(Order = 5)]
        public bool? Managed { get; set; }

        /// <summary>
        /// Gets or sets the content type.
        /// </summary>
        [JsonProperty(Order = 7)]
        public string ContentType { get; set; }

        /// <summary>
        /// Gets or sets the recovery level.
        /// </summary>
        [JsonProperty(Order = 8)]
        public string RecoveryLevel { get; set; }

        /// <summary>
        /// Gets or sets the date/time when the secret was created.
        /// </summary>
        [JsonProperty(Order = 9)]
        public DateTimeOffset Created { get; set; }

        /// <summary>
        /// Gets or sets the date/time when the secret was updated.
        /// </summary>
        [JsonProperty(Order = 10)]
        public DateTimeOffset Updated { get; set; }

        /// <summary>
        /// Gets or sets the date/time when the secret expires.
        /// </summary>
        [JsonProperty(Order = 11)]
        public DateTimeOffset? Expires { get; set; }

        /// <summary>
        /// Gets or sets the date/time when the secret becomes valid.
        /// </summary>
        [JsonProperty(Order = 12)]
        public DateTimeOffset? NotBefore { get; set; }
    }
}