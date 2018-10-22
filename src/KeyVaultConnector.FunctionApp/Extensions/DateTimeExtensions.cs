using System;

namespace KeyVaultConnector.FunctionApp.Extensions
{
    /// <summary>
    /// This represents the extension entity for <see cref="DateTime"/>.
    /// </summary>
    public static class DateTimeExtensions
    {
        /// <summary>
        /// Converts the <see cref="DateTime"/> value to <see cref="DateTimeOffset"/> value.
        /// </summary>
        /// <param name="dt"><see cref="Nullable{DateTime}"/> value.</param>
        /// <returns><see cref="Nullable{DateTimeOffset}"/> value.</returns>
        public static DateTimeOffset? ToDateTimeOffset(this DateTime? dt)
        {
            if (!dt.HasValue)
            {
                return null;
            }

            var dto = new DateTimeOffset(dt.Value);

            return dto;
        }
    }
}