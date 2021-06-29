using System;
using System.Collections.Generic;
using UnityEngine;

namespace Project.Scripts.Utils.EventBus
{
    public static class EventBus
    {
        private static Dictionary<Type, SubscribersList<IGlobalSubscriber>> _subscribers
            = new Dictionary<Type, SubscribersList<IGlobalSubscriber>>();

        public static void Subscribe(IGlobalSubscriber subscriber)
        {
            List<Type> subscriberTypes = СaсhedTypes.GetSubscriberTypes(subscriber);
            foreach (Type t in subscriberTypes)
            {
                if (!_subscribers.ContainsKey(t))
                {
                    _subscribers[t] = new SubscribersList<IGlobalSubscriber>();
                }
                _subscribers[t].Add(subscriber);
            }
        }

        public static void Unsubscribe(IGlobalSubscriber subscriber)
        {
            List<Type> subscriberTypes = СaсhedTypes.GetSubscriberTypes(subscriber);
            foreach (Type t in subscriberTypes)
            {
                if (_subscribers.ContainsKey(t))
                    _subscribers[t].Remove(subscriber);
            }
        }

        public static void RaiseEvent<TSubscriber>(Action<TSubscriber> action)
            where TSubscriber : class, IGlobalSubscriber
        {
            SubscribersList<IGlobalSubscriber> subscribers = _subscribers[typeof(TSubscriber)];

            subscribers.IsExecuting = true;
            foreach (IGlobalSubscriber subscriber in subscribers.List)
            {
                try
                {
                    action.Invoke(subscriber as TSubscriber);
                }
                catch (Exception e)
                {
                    Debug.LogError(e);
                }
            }
            subscribers.IsExecuting = false;
            subscribers.Cleanup();
        }
    }
}