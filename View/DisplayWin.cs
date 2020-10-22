using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace MyLabyrinth
{
    public class DisplayWin : MonoBehaviour
    {
        #region Fields

        private RestartButton _button;
        private Image _winImage;

        #endregion


        #region UnityMethods

        private void Start()
        {
            _winImage = GetComponent<Image>();
            _button = FindObjectOfType<RestartButton>();
        }

        #endregion


        #region Methods

        public void ShowWin(object o, PlayerEventArgs args)
        {
            _winImage.fillAmount = 1.0f;
            Time.timeScale = 0.0f;
            
            _button.ActivateButton(true);
        }

        #endregion
    }
}