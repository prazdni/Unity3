using System;
using UnityEditor;
using UnityEngine;

namespace MyLabyrinth
{
    [CustomEditor(typeof(BonusCharacteristics))]
    public class BonusEditor : Editor
    {
        #region Methods

        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            
            Transform bonusTransformParent = (target as BonusCharacteristics).transform;

            EditorGUILayout.LabelField("Bonus scale");
            
            var scale = bonusTransformParent.localScale.x;
            scale = EditorGUILayout.Slider(scale, 0.0f, 2.0f);

            bonusTransformParent.localScale = new Vector3(scale, scale, scale);
        }

        #endregion
    }
}