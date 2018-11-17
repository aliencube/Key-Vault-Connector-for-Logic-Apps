namespace KeyVaultConnector.FunctionApp.Configurations
{
    /// <summary>
    /// This represents the app settings entity for Key Vault.
    /// </summary>
    public class KeyVaultSettings
    {
        /// <summary>
        /// Gets or sets the Key Vault instance name.
        /// </summary>
        public virtual string Name { get; set; }

        /// <summary>
        /// Gets the base URI of Key Vault.
        /// </summary>
        public virtual string BaseUri => $"https://{this.Name}.vault.azure.net/";
    }
}
