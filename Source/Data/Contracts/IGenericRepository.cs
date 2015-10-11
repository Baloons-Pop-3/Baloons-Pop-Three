//-----------------------------------------------------------------------
// <copyright file="ICommand.cs" company="Baloons-Pop-Three">
//    Copyright Baloons-Pop-Three. All rights reserved
// </copyright>
// <summary>This is the ICommand interface.</summary>
//-----------------------------------------------------------------------
namespace BalloonsPop.Data.Contracts
{
    using System.Collections.Generic;
    using BalloonsPop.Models.Contracts;

    /// <summary>
    /// Interface for generic representation of the repository class.
    /// </summary>
    /// <typeparam name="T">Data type.</typeparam>
    public interface IGenericRepository<T> where T : IModel
    {
        IEnumerable<T> All();

        T Find(object id);

        void Add(T entity);
    }
}