using System;

namespace KeyVaultConnector.FunctionApp.Models
{
    /// <summary>
    /// This represents the model entity for secret.
    /// </summary>
    public class SecretModel
    {
        /// <summary>
        /// Gets or sets the Id.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the value.
        /// </summary>
        public string Value { get; set; }

        /// <summary>
        /// Gets or sets the value indicating whether the secret is enabled or not.
        /// </summary>
        public bool Enabled { get; set; }

        /// <summary>
        /// Gets or sets the value indicating whether the secret is managed or not.
        /// </summary>
        public bool? Managed { get; set; }

        /// <summary>
        /// Gets or sets the version.
        /// </summary>
        public string Version { get; set; }

        /// <summary>
        /// Gets or sets the content type.
        /// </summary>
        public string ContentType { get; set; }

        /// <summary>
        /// Gets or sets the recovery level.
        /// </summary>
        public string RecoveryLevel { get; set; }

        /// <summary>
        /// Gets or sets the date/time when the secret was created.
        /// </summary>
        public DateTimeOffset Created { get; set; }

        /// <summary>
        /// Gets or sets the date/time when the secret was updated.
        /// </summary>
        public DateTimeOffset Updated { get; set; }

        /// <summary>
        /// Gets or sets the date/time when the secret expires.
        /// </summary>
        public DateTimeOffset? Expires { get; set; }

        /// <summary>
        /// Gets or sets the date/time when the secret becomes valid.
        /// </summary>
        public DateTimeOffset? NotBefore { get; set; }
    }
}