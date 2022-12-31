using FrameworkCore.Event;
using FrameworkCore.Plugin;
using FrameworkCore.State;

namespace FrameworkCore
{

    public class FCore: FCoreBase
    {

        private FCore() { }

        public static FCore Create()
        {
            return new FCore();
        }

    }
}