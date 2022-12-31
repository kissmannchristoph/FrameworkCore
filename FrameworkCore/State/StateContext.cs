using FrameworkCore.Event;
using FrameworkCore.Util;
using Newtonsoft.Json;

namespace FrameworkCore.State
{
    internal interface IData
    {

    }

    internal class StateWatch
    {
        public readonly string Index;
        public readonly EventContext EventContext;
        public readonly string EventName;

        public StateWatch(string index, EventContext eventContext, string eventName)
        {
            this.Index = index;
            this.EventContext = eventContext;
            this.EventName = eventName;
        }
    }

    internal class StateWatchCheck
    {
        public readonly bool Exists;
        public readonly StateWatch? StateWatch;

        public StateWatchCheck(StateWatch stateWatch)
        {
            this.Exists = (stateWatch != null);
            this.StateWatch = (this.Exists) ? stateWatch : null;
        }
    }

    public class StateContext
    {
        public readonly string Name;
        Dictionary<string, object> data = new Dictionary<string, object>();
        List<StateWatch> stateWatches = new List<StateWatch>();

        public StateContext(string name)
        {
            this.Name = name;
        }

        private StateWatchCheck isWatch(string index)
        {
            bool exists = this.stateWatches.Find((StateWatch stateWatch) => stateWatch.Index.Equals(index)) != null;
            StateWatchCheck stateWatchCheck = new StateWatchCheck(this.stateWatches.Find((StateWatch stateWatch) => stateWatch.Index.Equals(index)));
            return stateWatchCheck;
        }

        private void registerWatch(string index, EventContext eventContext, string eventName)
        {
            this.stateWatches.Add(new StateWatch(index, eventContext, eventName));
        }

        private object get(string index)
        {
            return this.data[index];
        }

        public void RegisterWatch(string index, EventContext eventContext, string eventName)
        {
            this.registerWatch(index, eventContext, eventName);
        }

        public T Get<T>(string index)
        {
            return TypeUtils.ReType<T>(this.get(index));
        }

        public void Set(string index, object obj)
        {
            //check watch
            StateWatchCheck stateWatchCheck = this.isWatch(index);

            if (stateWatchCheck.Exists)
            {
                StateWatch stateWatch = stateWatchCheck.StateWatch;

            }
        }

        private object getData(string index)
        {
            return this.data[index];
        }
    }

}
