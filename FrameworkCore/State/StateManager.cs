using FrameworkCore.Event;
using Newtonsoft.Json;

namespace FrameworkCore.State
{
    public class StateManager
    {
        private readonly List<StateContext> stateContexts = new List<StateContext>();

        public StateManager() { }

        public StateContext GetStateContext(string name = "default")
        {
            return this.getStateContext(name);
        }

        private StateContext getStateContext(string name)
        {
            var stateContext = this.stateContexts.Find((StateContext el) => el.Name.Equals(name));

            if (stateContext == null)
                stateContext = this.getNewStateContext(name);

            return stateContext;
        }

        private StateContext getNewStateContext(string name)
        {
            return new StateContext(name);
        }
    }
}
