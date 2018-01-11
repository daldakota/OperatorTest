using UnityEngine;
using System.Collections;
using UnityEditor;

public class MakeScriptableObject {
    [MenuItem("Assets/Create/Story Event")]
    public static void CreateMyAsset()
    {
        StoryEvent asset = ScriptableObject.CreateInstance<StoryEvent>();

        AssetDatabase.CreateAsset(asset, "Assets/NewStoryEvent.asset");
        AssetDatabase.SaveAssets();

        EditorUtility.FocusProjectWindow();

        Selection.activeObject = asset;
    }
}