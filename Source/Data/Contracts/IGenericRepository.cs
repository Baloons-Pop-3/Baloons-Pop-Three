namespace BalloonsPop.Data
{
    using System.Collections.Generic;
    using BalloonsPop.Models.Contracts;

    internal interface IGenericRepository<T> where T : IModel
    {
        IEnumerable<T> All();

        T Find(object id);

        void Add(T entity);
    }
}