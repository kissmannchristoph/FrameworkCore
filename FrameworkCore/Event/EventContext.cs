using FrameworkCore.Util;
using FrameworkCore.Plugin;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text.Json.Serialization;
using System.Globalization;
using static FrameworkCore.Event.EventContext;
using System.Reflection.Metadata;
using System;

using JsonConverter = Newtonsoft.Json.JsonConverter;
using JsonConvert = Newtonsoft.Json.JsonConvert;

namespace FrameworkCore.Event
{
    [JsonConverter(typeof(EventContextBase))]
    public abstract class EventContextBase
    {
     
    }

    [JsonConverter(typeof(EventContext))]
    public class EventContext: EventContextBase
    {
        public string name;
        public List<Listener> listeners = new List<Listener>();

        public void FireEvent(Event _event) {
            List<IEventActionsData> eventActionsDatas = this.getEventActions(_event);

            foreach (IEventActionsData eventActionsData in eventActionsDatas)
            {
                _event.Bevore();

                if (eventActionsData != null)
                {
                    _event.Run();

                    //Type lType = eventActionsData.listener.GetType();
                    //ConstructorInfo lConstructor = lType.GetConstructor(Type.EmptyTypes);
                    //object magicClassObject = lConstructor.Invoke(new object[] { });

                    //object classInstance = Activator.CreateInstance(eventActionsData!.listener.GetType())!;
                    //eventActionsData.listener.Inv
                    eventActionsData.methodInfo.Invoke(eventActionsData.listener, new object[] { _event });
                }

                _event.After();
            }
        }

        public void RegisterListener(Listener listener)
        {
            if (!this.listeners.Contains(listener))
                this.listeners.Add(listener);
        }

        public void UnregisterListener(Listener listener)
        {
            this.listeners.Remove(listener);
        }

        private List<IEventActionsData> getEventActions(Event _event)
        {
            List <IEventActionsData> eventActionsDatas = new List <IEventActionsData>();

            foreach (Listener listener in this.listeners) 
            {
                List<MethodInfo> methods = ListUtils.ArrayToList< MethodInfo > (listener.GetType().GetMethods()); // TypeUtils.ReType<List<JMethodInfo>>();
                List<MethodInfo> filteredMethodsByEventHandler = new List<MethodInfo>();

                foreach (MethodInfo mi in methods)
                {
                    bool add = false;

                    foreach (var attr in mi.GetCustomAttributes<EventHandler>())
                    {
                        add = true;
                    }

                    if (add)
                        filteredMethodsByEventHandler.Add(mi);
                }

                //List<JMethodInfo> filteredMethodsByEventHandler = methods.FindAll((JMethodInfo methodInfo) => methodInfo.GetCustomAttributes<EventHandler>() != null);

                foreach (MethodInfo methodInfo in filteredMethodsByEventHandler)
                {
                    List <ParameterInfo> parameters = new List<ParameterInfo>(methodInfo.GetParameters());//TypeUtils.ReType<List<ParameterInfo>>(methodInfo.GetParameters());

                    if (parameters.Count == 0)
                        break;

                    ParameterInfo parameterInfo = parameters[0];
                    //parameterInfo.Member.GetCustomAttributes();
                   // Type type = parameterInfo.GetType();

                   // if (type.IsAssignableFrom(_event.GetType()))
                   if (parameterInfo.Member.GetCustomAttributes<EventHandler>().ToArray().Length > 0)
                    {
                        //Action action = (Action) Delegate.CreateDelegate(typeof(Action), listener, methodInfo);
                        
                        //var iead = JSON.Parse<IEventActionsData>("{'listener': '" + JsonConvert.SerializeObject(listener) + "', 'methodInfo': '" + JsonConvert.SerializeObject(methodInfo) + "'}")!;
                        eventActionsDatas.Add(new IEventActionsData() { listener = listener, methodInfo = methodInfo });
                        //eventActionsDatas.Add(JsonConvert.DeserializeObject<IEventActionsData>(JsonConvert.SerializeObject((object)iead)));
                    }
                }
            }

            return eventActionsDatas;
        }
    }

}
