﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kit.Core
{
    public static class ExceptionExtensions
    {
        /// <summary>
        /// Returns a list of all the exception messages from the top-level
        /// exception down through all the inner exceptions. Useful for making
        /// logs and error pages easier to read when dealing with exceptions.
        /// Usage: Exception.Messages()
        /// </summary>
        public static IEnumerable<string> Messages(this Exception ex)
        {
            // return an empty sequence if the provided exception is null
            if (ex == null)
                yield break;

            // first return THIS exception's message at the beginning of the list
            yield return ex.Message;

            // then get all the lower-level exception messages recursively (if any)
            IEnumerable<Exception> innerExceptions = Enumerable.Empty<Exception>();

            AggregateException aex = ex as AggregateException;
            if (aex != null && aex.InnerExceptions.Any())
                innerExceptions = aex.InnerExceptions;

            else if (ex.InnerException != null)
                innerExceptions = new[] { ex.InnerException };

            foreach (Exception innerEx in innerExceptions)
            {
                foreach (string msg in innerEx.Messages())
                {
                    yield return msg;
                }
            }
        }
    }
}
