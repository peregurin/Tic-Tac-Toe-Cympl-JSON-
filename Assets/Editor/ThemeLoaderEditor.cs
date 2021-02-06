using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(ThemeLoaderScript))]
public class ThemeLoaderEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        EditorGUILayout.LabelField("", GUI.skin.horizontalSlider);
        if (GUILayout.Button("Set Theme"))
        {
            ((ThemeLoaderScript)target).SetTheme();
        }
    }
}
