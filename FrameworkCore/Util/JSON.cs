using FrameworkCore.Event;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrameworkCore.Util
{
    internal class JSON
    {
        public static T Parse<T>(string json)
        {
            return JsonConvert.DeserializeObject<T>(json);
        }

        public static string Stringify(object obj)
        {
            return JsonConvert.SerializeObject(obj);
        }

      /*  string json = @"
        
            {
                ""name"": ""+name+"",
                ""listener"": ""[]""
           
            }
        "
;
      */
        
    }
}
