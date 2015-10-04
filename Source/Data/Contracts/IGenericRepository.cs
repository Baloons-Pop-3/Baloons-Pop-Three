namespace BalloonsPop.Data.Contracts
{
    using System.Collections.Generic;
    using BalloonsPop.Models.Contracts;

    public interface IGenericRepository<T> where T : IModel
    {
        IEnumerable<T> All();

        T Find(object id);

        void Add(T entity);
    }
}