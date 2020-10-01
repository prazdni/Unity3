using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace MyLabyrinth
{
    public class DisplayWin : MonoBehaviour
    {
        private Image _winImage;
        private void Start()
        {
            _winImage = GetComponent<Image>();
        }

        public void ShowWin(object o, PlayerEventArgs args)
        {
            _winImage.fillAmount = 1.0f;
            Time.timeScale = 0.0f;
        }
    }
}