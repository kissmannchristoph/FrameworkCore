using FrameworkCore.Event;

using FrameworkCore.State;

using FrameworkCore.Plugin;
using FrameworkCore.Module;

namespace FrameworkCore
{
    public abstract class Base
    {
        public readonly EventManager EventManager;
        public readonly PluginManager PluginManager;
        public readonly StateManager StateManager;
        public readonly ModuleManager ModuleManager;

        public Base(bool isPlugin = false, ModuleType? moduleType = null)
        {

            this.EventManager = new EventManager();
            if (!isPlugin)
                this.PluginManager = new PluginManager(this);
            this.StateManager = new StateManager();
            this.ModuleManager = new ModuleManager(this);
        }

        public T GetPlugin<T>(string name)
        {
            return this.PluginManager.GetPlugin<T>(name);
        }

        public StateContext GetDefaultState()
        {
            return this.StateManager.GetStateContext();
        }



    }
    public class PluginBase: Base
    {
        

        public PluginBase(): base(true)
        {
        }

    }
}
