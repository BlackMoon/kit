using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kit.Core.Extensions
{
    public static class DateTimeExtensions
    {
        /// <summary>
        /// Get this datetime as a Unix epoch timestamp (seconds since Jan 1, 1970, midnight UTC).
        /// </summary>
        /// <param name="date">The date to convert.</param>
        /// <returns>Seconds since Unix epoch.</returns>
        public static long ToUnixEpochDate(this DateTime date) => new DateTimeOffset(date).ToUniversalTime().ToUnixTimeSeconds();
    }
}
