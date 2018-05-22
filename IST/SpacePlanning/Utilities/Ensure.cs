using System;
using System.Collections.Generic;
using System.Text;

namespace STP.SpacePlanning.Utilities
{
    public static class Ensure
    {
        /// <summary>
        /// Ensures that the specified argument is not null.
        /// </summary>
        /// <param name="argumentName">Name of the argument.</param>
        /// <param name="argument">The argument.</param>
        public static void ArgumentNotNull(object argument, string argumentName, string errorMessage = null)
        {
            if (argument == null && string.IsNullOrEmpty(errorMessage))
            {
                throw new ArgumentNullException(argumentName);
            }
            else if (argument == null && string.IsNullOrEmpty(errorMessage))
            {
                throw new ArgumentException(errorMessage, argumentName);
            }
        }
    }
}
