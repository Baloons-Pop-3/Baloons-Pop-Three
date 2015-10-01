namespace BalloonsPop.Data
{
    using BalloonsPop.Models.Contracts;
    using System.Collections.Generic;

    internal interface IGenericRepository<T> where T : IModel
    {
        IEnumerable<T> All();

        T Find(object id);

        void Add(T entity);
    }
}