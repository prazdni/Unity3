using System;
using UnityEngine;
using UnityEngine.UI;
using Object = UnityEngine.Object;

namespace MyLabyrinth
{
    public class MyMiniMap : MonoBehaviour
    {
        private Image _image;
        private Transform _ball;
        private Vector2 _startPoint;
        [SerializeField] private Vector2 _multiplier = new Vector2(6.0f, 5.6f);
        private void Start()
        {
            _startPoint = new Vector2(-80, 77);
            _ball = FindObjectOfType<PlayerBase>().transform;
            
            transform.localPosition = new Vector3(_startPoint.x, _startPoint.y, 0);
        }

        private void Update()
        {
            if (Time.frameCount % 2 == 0)
            {
                transform.localPosition = new Vector3(_startPoint.x - _ball.transform.localPosition.x * _multiplier.x,
                    _startPoint.y - _ball.transform.localPosition.z * +_multiplier.y, 0);
            }
        }
    }
}