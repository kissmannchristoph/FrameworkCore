using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrameworkCore.Util
{
    public class ListUtils
    {
        public static List<T> ArrayToList<T>(T[] arr)
        {
            if (arr == null)
                return new List<T>();

            return new List<T>(arr);
        }
    }
}
