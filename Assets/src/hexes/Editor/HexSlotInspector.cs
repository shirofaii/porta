using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEditorInternal;
using UnityEngine;

[CustomEditor(typeof(HexSlot))]
public class HexSlotInspector : Editor {
    ReorderableList list;

    void OnEnable() {
        list = new ReorderableList(serializedObject, serializedObject.FindProperty("tiles"), true, true, true, true);
        list.drawHeaderCallback = rect => {
            EditorGUI.LabelField(rect, "Tiles");
        };
    }

	public override void OnInspectorGUI() {
		serializedObject.Update();
		list.DoLayoutList();
		serializedObject.ApplyModifiedProperties();
	}
}