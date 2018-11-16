using Newtonsoft.Json;

namespace KeyVaultConnector.FunctionApp.Models
{
    /// <summary>
    /// This represents the model entity for errors.
    /// </summary>
    public class ErrorModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ErrorModel"/> class.
        /// </summary>
        /// <param name="statusCode">HTTP status code.</param>
        /// <param name="message">Error message.</param>
        public ErrorModel(int statusCode, string message)
        {
            this.StatusCode = statusCode;
            this.Message = message;
        }

        /// <summary>
        /// Gets or sets the HTTP status code.
        /// </summary>
        [JsonProperty(Order = 1)]
        public int StatusCode { get; set; }

        /// <summary>
        /// Gets or sets the error message.
        /// </summary>
        [JsonProperty(Order = 2)]
        public string Message { get; set; }
    }
}
