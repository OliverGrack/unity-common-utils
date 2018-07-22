using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UCU {
    public static partial class CollectionExtentions {
        public static T RandomItem<T>(this List<T> list) {
            return list[Random.Range(0, list.Count)];
        }
        public static T RandomItem<T>(this T[] list) {
            return list[Random.Range(0, list.Length)];
        }

        public static T RemoveRandom<T>(this IList<T> list) {
            if (list.Count == 0) throw new System.IndexOutOfRangeException("Cannot remove a random item from an empty list");
            int index = Random.Range(0, list.Count);
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
                int k = Random.Range(0, n + 1);
                T value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }
    }
}