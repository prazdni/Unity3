using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace MyLabyrinth
{
    public class Radar : MonoBehaviour
    {
        private Image _map;
        private Transform _playerPos;
        private readonly float _mapScale = 2;
        public static List<RadarObject> RadObjects = new List<RadarObject>();
        [SerializeField] private Vector3 _offset;

        private void Start()
        {
            _offset = new Vector3(0, 0, 4.0f);
            _map = GetComponent<Image>();
            _playerPos = Camera.main.transform;
            _playerPos.position += _offset;
        }

        public static void RegisterRadarObject(GameObject o, Image i)
        {
            Image image = Instantiate(i);
            image.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
            RadObjects.Add(new RadarObject{Owner = o, Icon = image});
        }

        public static void RemoveRadarObject(GameObject o)
        {
            List<RadarObject> newList = new List<RadarObject>();

            foreach (var t in RadObjects)
            {
                if (t.Owner == o)
                {
                    Destroy(t.Icon);
                    continue;
                }
                newList.Add(t);
            }
            RadObjects.RemoveRange(0, RadObjects.Count);
            RadObjects.AddRange(newList);
        }

        private void DrawRadarDots()
        {
            _playerPos.position -= _offset;
            foreach (var radObject in RadObjects)
            {
                Vector3 radarPos = (radObject.Owner.transform.position - _playerPos.position);
                float distToObject = Vector3.Distance(_playerPos.position, radObject.Owner.transform.position) *
                                     _mapScale;
                float deltaY = Mathf.Atan2(radarPos.x, radarPos.z) * Mathf.Rad2Deg - 270 - _playerPos.eulerAngles.y;
                radarPos.x = distToObject * Mathf.Cos(deltaY * Mathf.Deg2Rad) * -1;
                radarPos.z = distToObject * Mathf.Sin(deltaY * Mathf.Deg2Rad);
                radObject.Icon.transform.SetParent(transform);
                radObject.Icon.transform.position = new Vector3(radarPos.x, radarPos.z, 0) + transform.position;
                
                
            }
        }

        private void Update()
        {
            if (Time.frameCount % 2 == 0)
            {
                DrawRadarDots();
            }
        }
    }
}