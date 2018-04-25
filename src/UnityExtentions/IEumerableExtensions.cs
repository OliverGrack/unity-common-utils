using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class IEnumerableExtensions {
    public static T RandomItem<T> (this List<T> list) {
        return list[Random.Range(0, list.Count)];
    }
    public static T RandomItem<T>(this T[] list) {
        return list[Random.Range(0, list.Length)];
    }
}
