using UnityEditor;
using UnityEngine;

namespace MyLabyrinth
{
    public class CreateBonusWindow : EditorWindow
    {
        public static GameObject InstantiatableObject;
        private bool _isSetPosition;
        private Vector3 pos;
        private void OnGUI()
        {
            EditorGUILayout.LabelField("Bonus description", EditorStyles.boldLabel);

            InstantiatableObject =
                EditorGUILayout.ObjectField("Project bonus", InstantiatableObject, typeof(GameObject), false) as
                    GameObject;
            
            _isSetPosition = EditorGUILayout.BeginToggleGroup("Set position", _isSetPosition);
            
            if (_isSetPosition)
            {
                pos = EditorGUILayout.Vector3Field("Position", pos);
            }
            else
            {
                pos = Vector3.zero;
            }

            EditorGUILayout.EndToggleGroup();
            
            var button = GUILayout.Button("Add bonus to scene");
            
            if (button)
            {
                if (InstantiatableObject)
                {
                    GameObject root = new GameObject("Bonuses");
                    GameObject temp = Instantiate(InstantiatableObject, pos, Quaternion.identity);
                    temp.name = "BonusCube";
                    temp.transform.parent = root.transform;
                }
                else
                {
                    EditorWindow.GetWindow<FieldIsMissed>(true, "Something went wrong!");
                }
            }
        }
    }
}