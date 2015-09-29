using BalloonsPop.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BalloonsPop.Data
{
    interface IGenericRepository<T> where T :IModel
    {
        IEnumerable<T> All();

        T Find(object id);

        void Add(T entity);
    }
}
