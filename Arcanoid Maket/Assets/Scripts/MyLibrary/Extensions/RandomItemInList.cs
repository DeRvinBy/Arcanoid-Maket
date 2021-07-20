using System;
using System.Collections.Generic;
using System.Linq;
using Random = UnityEngine.Random;

namespace MyLibrary.Extensions
{
    public static class RandomItemInList
    {
        private const int MinRandomIndex = 0;
        
        public static T GetRandomItemByProbability<T>(this IEnumerable<T> list, Func<T, float> item)
        {
            var sum = list.Sum(item);
            
            var randomPoint = Random.value * sum;

            foreach (var arg in list)
            {
                var prob = item(arg);
                if (randomPoint < prob)
                {
                    return arg;
                }
                else
                {
                    randomPoint -= prob;
                }
            }

            return list.Last();
        }

        public static T GetRandomItem<T>(this IEnumerable<T> list)
        {
            var randomIndex = Random.Range(MinRandomIndex, list.Count());
            return list.ElementAt(randomIndex);
        }
    }
}