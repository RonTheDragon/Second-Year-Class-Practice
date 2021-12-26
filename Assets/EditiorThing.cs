using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;


public class EditiorThing : EditorWindow
{
    string name;

    [MenuItem("Window/bruh")]
    public static void ShowWindow()
    {
        GetWindow<EditiorThing>("bruh");
    }

    private void OnGUI()
    {
        GUILayout.Label(name, EditorStyles.boldLabel);
        name = EditorGUILayout.TextField("The "+name, name);
    }
}
