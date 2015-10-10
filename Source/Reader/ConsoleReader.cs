//-----------------------------------------------------------------------
// <copyright file="ConsoleReader.cs" company="Baloons-Pop-Three">
//    Copyright Baloons-Pop-Three. All rights reserved
// </copyright>
// <summary>This is the ConsoleReader class.</summary>
//-----------------------------------------------------------------------
namespace BalloonsPop.Reader
{
    using System;
    using BalloonsPop.Reader.Contracts;

    /// <summary>
    /// A single-instance class that provides a method for reading from the console.
    /// </summary>
    internal sealed class ConsoleReader : IReader
    {
        /// <summary>
        /// The instance of the <see cref="ConsoleReader"/> class.
        /// </summary>
        private static ConsoleReader instance;

        /// <summary>
        /// Prevents a default instance of the <see cref="ConsoleReader"/> class from being created.
        /// </summary>
        private ConsoleReader()
        {
        }

        /// <summary>
        /// Gets the instance from the <see cref="ConsoleReader"/> class.
        /// </summary>
        public static ConsoleReader Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ConsoleReader();
                }

                return instance;
            }
        }

        /// <summary>
        /// Reads the input from the console.
        /// </summary>
        /// <returns>String with the input value.</returns>
        public string ReadInput()
        {
            return Console.ReadLine();
        }
    }
}