using System;
using UnityEngine;
using UnityEngine.UI;
using Object = UnityEngine.Object;

namespace MyLabyrinth
{
    public sealed class DisplayKey : MonoBehaviour
    {
        #region Fields

        private Image _keyImage;

        #endregion


        #region UnityMethods

        private void Start()
        {
            _keyImage = GetComponent<Image>();
        }

        #endregion

        
        #region Methods

        public void ShowKey(object o, PlayerEventArgs args)
        {
            _keyImage.fillAmount = 1.0f;
        }

        #endregion
    }
}