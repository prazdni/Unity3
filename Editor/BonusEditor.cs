using System;
using UnityEditor;
using UnityEngine;

namespace MyLabyrinth
{
    [CustomEditor(typeof(Bonus))]
    public class BonusEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            
            Transform bonusTransformParent = (target as Bonus).transform.parent;

            EditorGUILayout.LabelField("Bonus scale");
            
            var scale = bonusTransformParent.localScale.x;
            scale = EditorGUILayout.Slider(scale, 0.0f, 2.0f);

            bonusTransformParent.localScale = new Vector3(scale, scale, scale);
        }
    }
}