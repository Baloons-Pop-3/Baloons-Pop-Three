using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BalloonsPop.Models.Contracts
{
    interface IPrototype<T> where T : class
    {
        T Clone();
    }
}
