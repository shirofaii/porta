using UnityEngine;
using System.IO;
using System.Collections.Generic;
using System.Collections;

public static class ListExtensions {
	public static T AtRandom<T>(this List<T> list) {
        return list[Random.Range(0, list.Count)];
    }

	public static T AtRandom<T>(this T[] list) {
        return list[Random.Range(0, list.Length)];
    }

	public static T TakeRandom<T>(this List<T> list) {
        var idx = Random.Range(0, list.Count);
        var el = list[idx];
        list.RemoveAt(idx);
        return el;
    }
}

