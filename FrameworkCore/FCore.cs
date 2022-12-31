using FrameworkCore.Event;
using System.Runtime.CompilerServices;

namespace FrameworkCore
{
   
    public class FCore
    {
       readonly EventManager eventManager;

       public FCore()
       {
            this.eventManager = new EventManager();
       }

    }
}