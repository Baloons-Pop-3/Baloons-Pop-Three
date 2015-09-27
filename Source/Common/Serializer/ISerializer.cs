using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BalloonsPop.Common.Serializer
{
    interface ISerializer 
    {
        string Serialize<T>(T entity) where T :class;

        T Deserialize<T>(string input) where T : class;
    }
}
