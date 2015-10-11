//-----------------------------------------------------------------------
// <copyright file="CommandValidator.cs" company="Baloons-Pop-Three">
//    Copyright Baloons-Pop-Three. All rights reserved
// </copyright>
// <summary>This is the CommandValidator class.</summary>
//-----------------------------------------------------------------------
namespace BalloonsPop.Common.Validators
{
    using System;
    using System.Linq;
    using Constants;

    /// <summary>
    /// Class for all command validations.
    /// </summary>
    /// <typeparam name="T">Type to validate.</typeparam>
    internal class CommandValidator<T>
    {
        /// <summary>
        /// Constructor - not accepting enumerations as type!
        /// </summary>
        public CommandValidator()
        {
            if (!typeof(T).IsEnum)
            {
                throw new ArgumentException(GlobalMessages.InvalidEnumerationExceptionMsg);
            }
        }

        /// <summary>
        /// Checks for valid command.
        /// </summary>
        /// <param name="input">Checked command</param>
        /// <returns>True if command is valid.</returns>
        internal bool IsValidCommand(string input)
        {
            if (!string.IsNullOrEmpty(input))
            {
                // transform the string into string with first uppercase letter.
                input = input.First().ToString().ToUpper() + string.Join(string.Empty, input.Skip(1));
            }

            if (!Enum.IsDefined(typeof(T), input))
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// Parses the type of the command from the enumeration.
        /// </summary>
        /// <param name="input">Input command.</param>
        /// <returns>The parsed type.</returns>
        internal T GetType(string input)
        {
            T type = (T)Enum.Parse(typeof(T), input, true);
            return type;
        }
    }
}