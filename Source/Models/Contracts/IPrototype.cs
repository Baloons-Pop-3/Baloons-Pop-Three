//-----------------------------------------------------------------------
// <copyright file="IPrototype.cs" company="Baloons-Pop-Three">
//    Copyright Baloons-Pop-Three. All rights reserved
// </copyright>
// <summary>This is the IPrototype interface.</summary>
//-----------------------------------------------------------------------
namespace BalloonsPop.Models.Contracts
{
    /// <summary>
    /// Interface that provides a method for cloning a class.
    /// </summary>
    /// <typeparam name="T">T is a class.</typeparam>
    public interface IPrototype<T> where T : class
    {
        /// <summary>
        /// Clones the class's instance.
        /// </summary>
        /// <returns>Cloned instance of the same class.</returns>
        T Clone();
    }
}