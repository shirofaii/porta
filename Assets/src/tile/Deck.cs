using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

[Serializable]
    public class DeckEntry {
    public int amount = 1;
    public GameObject prefab;
}

public class Deck : ScriptableObject {
    public List<DeckEntry> tiles;

#if UNITY_EDITOR
	[MenuItem("Assets/Create/Deck")]
	public static void CreateAsset() {
		EditorUtils.CreateAsset<Deck>();
	}
#endif
}
