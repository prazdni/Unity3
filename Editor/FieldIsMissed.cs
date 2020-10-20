using System;
using UnityEditor;
using UnityEngine;

namespace MyLabyrinth
{
    public class FieldIsMissed : EditorWindow
    {
        private void OnGUI()
        {
            EditorGUILayout.LabelField("Not every field is filled correctly");
            var button = GUILayout.Button("Fix it!");
            
            if (button)
            {
                EditorWindow.mouseOverWindow.Close();
            }
        }
    }
}