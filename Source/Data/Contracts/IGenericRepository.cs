using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BalloonsPop.Data
{
    interface IGenericRepository<T> where T :class
    {
        IEnumerable<T> All();

        T Find(object property);

        void Add(T entity);
    }
}
