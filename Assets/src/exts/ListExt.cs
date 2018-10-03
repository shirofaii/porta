using System;
using System.Collections.Generic;

public static class ListExt {
	public static bool IsNullOrEmpty<T>(this List<T> list) {
		if(list == null) return true;
		if(list.Count == 0) return true;
		return false;
	}

    public static List<T> Push<T>(this List<T> list, T item) {
        list.Add(item);
        return list;
    }

    public static T Pop<T>(this List<T> list) {
        if(list.Count == 0) return default(T);

        var item = list[list.Count - 1];
        list.RemoveAt(list.Count - 1);
        return item;
    }

    public static void Shuffle<T>(this List<T> list) {
        var rng = new System.Random();
        var n = list.Count;
        while (n > 1) {
            n--;
            var k = rng.Next(n + 1);
            var value = list[k];
            list[k] = list[n];
            list[n] = value;
        }
    }
}