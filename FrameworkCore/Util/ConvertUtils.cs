using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrameworkCore.Util
{
    public class ConvertUtils
    {

        public static List<T> ListToArray<T>(T[] list) {
            List<T> l = new List<T>();

            foreach(object o in list)
            {
                l.Add((T)o);
            }

            return l;
        }
    }

}
