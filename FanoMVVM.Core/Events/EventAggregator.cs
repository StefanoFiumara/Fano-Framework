using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace FanoMvvm.Events
{
    public class EventAggregator : IEventAggregator
    {
        private Dictionary<Type, IList> EventCollection { get; }

        public EventAggregator()
        {
            this.EventCollection = new Dictionary<Type, IList>();
        }

        public void Subscribe<TEvent, TEventArgs>(Action<TEventArgs> handler) where TEvent : BaseEvent<TEventArgs>
        {
            if (this.EventCollection.ContainsKey(typeof(TEvent)) == false)
            {
                this.EventCollection[typeof(TEvent)] = new List<Action<TEventArgs>> {handler};
            }
            else
            {
                this.EventCollection[typeof(TEvent)].Add(handler);
            }
        }

        public void Unsubscribe<TEvent, TEventArgs>(Action<TEventArgs> handler) where TEvent : BaseEvent<TEventArgs>
        {
            if (!this.EventCollection.ContainsKey(typeof(TEvent))) return;

            while (this.EventCollection[typeof(TEvent)].Contains(handler))
            {
                this.EventCollection[typeof(TEvent)].Remove(handler);
            }
        }

        public void Publish<TEvent, TEventArgs>(TEventArgs args) where TEvent : BaseEvent<TEventArgs>
        {
            if (!this.EventCollection.ContainsKey(typeof(TEvent))) return;

            var actions = this.EventCollection[typeof(TEvent)].Cast<Action<TEventArgs>>();

            foreach (var action in actions)
            {
                action.Invoke(args);
            }
        }

        public void Subscribe<TEvent>(Action handler) where TEvent : BaseEvent
        {
            if (this.EventCollection.ContainsKey(typeof(TEvent)) == false)
            {
                this.EventCollection[typeof(TEvent)] = new List<Action> { handler };
            }
            else
            {
                this.EventCollection[typeof(TEvent)].Add(handler);
            }
        }

        public void Unsubscribe<TEvent>(Action handler) where TEvent : BaseEvent
        {
            if (!this.EventCollection.ContainsKey(typeof(TEvent))) return;

            while (this.EventCollection[typeof(TEvent)].Contains(handler))
            {
                this.EventCollection[typeof(TEvent)].Remove(handler);
            }
        }

        public void Publish<TEvent>() where TEvent : BaseEvent
        {
            if (!this.EventCollection.ContainsKey(typeof(TEvent))) return;

            var actions = this.EventCollection[typeof(TEvent)].Cast<Action>();

            foreach (var action in actions)
            {
                action.Invoke();
            }
        }
    }
}