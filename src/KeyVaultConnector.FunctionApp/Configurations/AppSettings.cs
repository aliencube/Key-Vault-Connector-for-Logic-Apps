namespace KeyVaultConnector.FunctionApp.Configurations
{
    /// <summary>
    /// This represents the app settings entity.
    /// </summary>
    public class AppSettings
    {
        /// <summary>
        /// Gets the <see cref="KeyVaultSettings"/> instance.
        /// </summary>
        public virtual KeyVaultSettings KeyVault => new KeyVaultSettings();
    }
}
