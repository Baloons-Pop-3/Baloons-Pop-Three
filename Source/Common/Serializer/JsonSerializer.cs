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
        private readonly JavaScriptSerializer serializer;

        public JsonSerializer()
        {
            this.serializer = new JavaScriptSerializer();
        }

        public  string Serialize<T>(T entity) where T :class
        {
            return serializer.Serialize(entity);
        }

        public T Deserialize<T>(string input) where T:class
        {
            return serializer.Deserialize<T>(input);
        }
    }
}
