using FrameworkCore.Util;
using FrameworkCore.Plugin;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text.Json.Serialization;

namespace FrameworkCore.Event
{
    [JsonConverter(typeof(EventContextBase))]
    public abstract class EventContextBase
    {
      
    }

    [JsonConverter(typeof(EventContext))]
    public abstract class EventContext: EventContextBase
    {
        public readonly string name;
        public List<Listener> listeners;

        public void FireEvent(Event _event) {

        }

        public void RegisterEvent

        private List<Action> getEventActions()
        {
            List <Action> actions = new List <Action>();

            foreach (Listener listener in this.listeners) 
            {
                List<MethodInfo> methods = TypeUtils.ReType<List<MethodInfo>>(listener.GetType().GetMethods().ToArray<MethodInfo>());
                List<MethodInfo> filteredMethodsByEventHandler = methods.FindAll((MethodInfo methodInfo) => methodInfo.GetCustomAttributes<EventHandler>() != null);
                
                foreach(MethodInfo methodInfo in filteredMethodsByEventHandler)
                {
                    List <ParameterInfo> parameters = TypeUtils.ReType<List<ParameterInfo>>(methodInfo.GetParameters().ToArray<ParameterInfo>());

                    if (parameters.Count == 0)
                        break;

                    ParameterInfo parameterInfo = parameters[0];
                    Type type = parameterInfo.GetType();

                    if (type.IsAssignableFrom(typeof(Event)))
                    {
                        Action action = (Action) Delegate.CreateDelegate(typeof(Action), listener, methodInfo);
                        actions.Add(action);
                    }
                }
            }

            return actions;
        }
    }

}
