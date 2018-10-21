using System;

namespace KeyVaultConnector.FunctionApp.Configurations
{
    /// <summary>
    /// This represents the app settings entity for Key Vault.
    /// </summary>
    public class KeyVaultSettings
    {
        private const string KeyVaultName = "KeyVault__Name";

        /// <summary>
        /// Gets the Key Vault instance name.
        /// </summary>
        public virtual string Name => Environment.GetEnvironmentVariable(KeyVaultName);

        /// <summary>
        /// Gets the base URI of Key Vault.
        /// </summary>
        public virtual string BaseUri => $"https://{this.Name}.vault.azure.net/";
    }
}
