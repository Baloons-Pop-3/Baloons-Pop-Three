using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace BalloonsPop.Common.Serializer
{

    class JsonSerializer:ISerializer
    {
        public  string Serialize<T>(T entity) where T :class
        {
            return JsonConvert.SerializeObject(entity);
        }

        public T Deserialize<T>(string input) where T:class
        {
            return JsonConvert.DeserializeObject<T>(input);
        }
    }
}
