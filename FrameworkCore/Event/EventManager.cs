﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using JsonConverter = Newtonsoft.Json.JsonConverter;
using JsonConverterAttribute = System.Text.Json.Serialization.JsonConverterAttribute;

namespace FrameworkCore.Event
{
    [JsonConverter(typeof(EventContext))]
    abstract class EventContext
    {
        public readonly string name;
        public Listener listener;
    }

    internal class EventManager
    {
        private List<EventContext> eventContexts = new List<EventContext>();

        public EventManager()
        {

        }

        public EventContext GetEventContext(string name = "default")
        {
            return this.getEventContext(name);
        }

        private EventContext getEventContext(string name)
        {
            var eventContext = this.eventContexts.Find((EventContext el) => el.name.Equals(name));

            if (eventContext == null)
                eventContext = this.getNewEventContext(name);

            return eventContext;
        }

        private EventContext getNewEventContext(string name)
        {
            string json = @"
        
            {
            ""name"": ""+name+"",
""listener"": ""[]""
                
            }
        "
            ;

            EventContext eventContext = JsonConvert.DeserializeObject<EventContext>(json);
            return eventContext;

            /*  string serializedAgain = JsonConvert.SerializeObject(list);
            Debug.WriteLine(serializedAgain);

            return new EventContext
            { "name" = "asd" };*/
        }
    }

    public interface Listener { }


}
