namespace BalloonsPop.Common.Validators
{
    using System;

    /// <summary>
    /// Base class where, validations are stored for eased accessibility.
    /// </summary>
    public static class Validator
    {
        // TODO: Add more validations if necessary.
        // TODO: Improve validations logic if necessary.

        /// <summary>
        /// Validates string inputs.
        /// </summary>
        /// <param name="propertyValue">The value of the input.</param>
        /// <param name="propertyName">The name of the parameter, makes debugging easier.</param>
        public static void ValidateString(string propertyValue, string propertyName)
        {
            if (string.IsNullOrEmpty(propertyValue))
            {
                throw new ArgumentOutOfRangeException(propertyName + " must not be null or empty.");
            }
        }
    }
}