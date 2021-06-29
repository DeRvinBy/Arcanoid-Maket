﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace Project.Scripts.Utils.EventBus
{
    internal static class СaсhedTypes
    {
        private static Dictionary<Type, List<Type>> _caсhedSubscriberTypes =
            new Dictionary<Type, List<Type>>();

        public static List<Type> GetSubscriberTypes(IGlobalSubscriber globalSubscriber)
        {
            Type type = globalSubscriber.GetType();
            if (_caсhedSubscriberTypes.ContainsKey(type))
            {
                return _caсhedSubscriberTypes[type];
            }

            List<Type> subscriberTypes = type
                .GetInterfaces()
                .Where(t => t.GetInterfaces()
                    .Contains(typeof(IGlobalSubscriber)))
                .ToList();

            _caсhedSubscriberTypes[type] = subscriberTypes;
            return subscriberTypes;
        }
    }
}
