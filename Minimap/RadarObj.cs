using System;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace MyLabyrinth
{
    public class RadarObj : MonoBehaviour
    {
        [SerializeField] private Image _icon;
        
        private void OnValidate()
        {
            _icon = Resources.Load<Image>("MiniMap/RadarObject");
        }

        private void OnDisable()
        {
            Radar.RemoveRadarObject(gameObject);
        }

        private void OnEnable()
        {
            Radar.RegisterRadarObject(gameObject, _icon);
        }
    }
}