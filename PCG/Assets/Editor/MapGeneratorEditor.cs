using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(Layout), true)]

public class CreateDungeon : Editor
{
    Layout layout;

    private void Awake()
    {
        layout = (Layout)target;
    }

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        if(GUILayout.Button("Create Dungeon"))
        {
            layout.MapGenerator();
        }
    }
}
