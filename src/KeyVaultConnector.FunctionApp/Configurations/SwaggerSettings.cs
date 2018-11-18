namespace KeyVaultConnector.FunctionApp.Configurations
{
    /// <summary>
    /// This represents the app settings entity for Swagger.
    /// </summary>
    public class SwaggerSettings
    {
        /// <summary>
        /// Gets or sets the URL to import Swagger definition.
        /// </summary>
        public virtual string ImportUrl { get; set; }
    }
}
