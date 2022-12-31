using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrameworkCore.Event
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
    public class EventHandler : Attribute
    {
        
    }
}
