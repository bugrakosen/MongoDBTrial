using Newtonsoft.Json;
using System.Collections.Generic;
using System.Dynamic;

namespace MongoDBTrial.Helpers.ExpandoLib
{
    public class ExpandoBuilder
    {
        public IDictionary<string, object> Props { get; set; }

        public ExpandoObject GetExpandoObject()
        {
            
            var q = new ExpandoObject() as IDictionary<string, object>;

            foreach (var item in Props)
            {
                q.Add(item.Key, item.Value);
            }

            //Type modelType = typeof(TModel);

            //modelType.GetProperties();
            var x = (ExpandoObject)q;
            var y = JsonConvert.SerializeObject(q);
            var z = JsonConvert.DeserializeObject(y);
            return (ExpandoObject)q;
        }
    }
}
