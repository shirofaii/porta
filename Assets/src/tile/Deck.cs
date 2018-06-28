using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class Deck : ScriptableObject {
    public List<TileDesc> tiles;

#if UNITY_EDITOR
	[MenuItem("Assets/Create/Deck")]
	public static void CreateAsset() {
		EditorUtils.CreateAsset<Deck>();
	}
#endif
}
