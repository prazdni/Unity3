using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace MyLabyrinth
{
    public class DisplayWin : MonoBehaviour
    {
        #region Fields

        private Image _winImage;

        #endregion


        #region UnityMethods

        private void Start()
        {
            _winImage = GetComponent<Image>();
        }

        #endregion


        #region Methods

        public void ShowWin(object o, PlayerEventArgs args)
        {
            _winImage.fillAmount = 1.0f;
            Time.timeScale = 0.0f;
        }

        #endregion
    }
}