using System;
using System.Collections.Generic;
using UnityEngine;

namespace UCU {
    public static partial class CollectionExtentions {
        public static T RandomItem<T>(this List<T> list) {
            return list[UnityEngine.Random.Range(0, list.Count)];
        }
        public static T RandomItem<T>(this T[] list) {
            return list[UnityEngine.Random.Range(0, list.Length)];
        }

        public static T RandomItemWeighted<T>(this IEnumerable<T> enumerable, Func<T, float> weightFunc) {
            float totalWeight = 0; // this stores sum of weights of all elements before current
            T selected = default(T); // currently selected element
            foreach (var data in enumerable) {
                float weight = weightFunc(data); // weight of current element
                float r = UnityEngine.Random.Range(0, totalWeight + weight); // random value
                if (r >= totalWeight) { // probability of this is weight/(totalWeight+weight)
                    selected = data; // it is the probability of discarding last selected element and selecting current one instead
                }
                totalWeight += weight; // increase weight sum
            }

            return selected; // when iterations end, selected is some element of sequence. 
        }

        public static T RemoveRandom<T>(this IList<T> list) {
            if (list.Count == 0) {
                throw new IndexOutOfRangeException("Cannot remove a random item from an empty list");
            }

            int index = UnityEngine.Random.Range(0, list.Count);
            T item = list[index];
            list.RemoveAt(index);
            return item;
        }

        /// <summary>
        /// Shuffle the list in place
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        public static void Shuffle<T>(this IList<T> list) {
            // using the Fisher-Yates method.
            int n = list.Count;
            while (n > 1) {
                n--;
                int k = UnityEngine.Random.Range(0, n + 1);
                T value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }
    }
}
