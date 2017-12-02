using System;

namespace FanoMvvm.Events
{
    public interface IEventAggregator
    {
        void Subscribe<TEvent, TEventArgs>(Action<TEventArgs> handler)
            where TEvent : BaseEvent<TEventArgs>;

        void Unsubscribe<TEvent, TEventArgs>(Action<TEventArgs> handler)
            where TEvent : BaseEvent<TEventArgs>;

        void Publish<TEvent, TEventArgs>(TEventArgs args)
            where TEvent : BaseEvent<TEventArgs>;

        void Subscribe<TEvent>(Action handler)
            where TEvent : BaseEvent;

        void Unsubscribe<TEvent>(Action handler)
            where TEvent : BaseEvent;

        void Publish<TEvent>()
            where TEvent : BaseEvent;
    }
}