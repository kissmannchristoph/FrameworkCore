using FrameworkCore.Event;
using FrameworkCore.Plugin;
using FrameworkCore.State;

namespace FrameworkCore
{

    public class FCore
    {
        public EventManager EventManagerContext { get; } = new EventManager();
        public PluginManager PluginManagerContext { get; } = new PluginManager();
        public StateManager StateManagerContext { get; } = new StateManager();

        private FCore() { }

        public static FCore Create()
        {
            return new FCore();
        }

    }
}