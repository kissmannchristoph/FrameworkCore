using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrameworkCore.Event
{
    public abstract class Event
    {
        public Event()
        {

        }

        public abstract void Bevore();
        public abstract void Run();
        public abstract void After();
    }
}
