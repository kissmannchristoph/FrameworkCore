using FrameworkCore.Event;
using FrameworkCore.Plugin;
using FrameworkCore.State;

namespace FrameworkCore
{

    public class FCore
    {
        public EventManager EventManager { get; } = new EventManager();
        public PluginManager PluginManager { get; } = new PluginManager();
        public StateManager StateManager { get; } = new StateManager();

        private FCore() { }

        public static FCore Create()
        {
            return new FCore();
        }

    }
}