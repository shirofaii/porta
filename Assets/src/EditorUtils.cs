#if UNITY_EDITOR
using UnityEngine;
using System.IO;
using UnityEditor;

public static class EditorUtils {
	public static void CreateAsset<T>() where T : ScriptableObject {
		var asset = ScriptableObject.CreateInstance<T>();
		var path = AssetDatabase.GetAssetPath(Selection.activeObject);

		if(path == "") {
			path = "Assets";
		} else if(Path.GetExtension(path) != "") {
			path = path.Replace(Path.GetFileName(AssetDatabase.GetAssetPath(Selection.activeObject)), "");
		}
 
		var assetPathAndName = AssetDatabase.GenerateUniqueAssetPath(path + "/New " + typeof(T).ToString() + ".asset");
		AssetDatabase.CreateAsset(asset, assetPathAndName);
		AssetDatabase.SaveAssets();
        AssetDatabase.Refresh();

		EditorUtility.FocusProjectWindow();
		Selection.activeObject = asset;
	}
}
#endif