using System;
using UnityEngine;
using UnityEngine.UI;
using Object = UnityEngine.Object;

namespace MyLabyrinth
{
    public sealed class DisplayKey : MonoBehaviour
    {
        private Image _keyImage;

        private void Start()
        {
            _keyImage = GetComponent<Image>();
        }

        public void ShowKey(object o, PlayerEventArgs args)
        {
            _keyImage.fillAmount = 1.0f;
        }
    }
}