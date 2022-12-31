using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrameworkCore.Util
{
    public class TypeUtils
    {
        public static T? ReType<T>(object obj)
        {
            string stringifyd = JsonConvert.SerializeObject(obj);
            return JsonConvert.DeserializeObject<T>(stringifyd);
        }
    }
}
