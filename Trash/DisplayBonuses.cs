using UnityEngine.UI;
using UnityEngine;
using static UnityEngine.Debug;


namespace MyLabyrinth
{
    public sealed class DisplayBonuses : IView
    {

        #region Fields

        private Text _text;

        private Image _hpBar;
        private Image _keyImage;
        private Image _exitImage;

        private float _maxHp = 10;
        private int _point;

        #endregion


        #region Properties

        public float HP
        {
            get => _hpBar.fillAmount;
        }

        #endregion


        #region Methods

        public DisplayBonuses(GameObject bonus)
        {
            _text = Object.FindObjectOfType<Text>();
            //var images = Object.FindObjectsOfType<Image>();
            var images = bonus.GetComponentsInChildren<Image>();
            foreach (var image in images)
            {
                if (image.gameObject.CompareTag("Bar"))
                {
                    _hpBar = image;
                }
                if (image.gameObject.CompareTag("Key"))
                {
                    _keyImage = image;
                }
                if (image.gameObject.CompareTag("Exit"))
                {
                    _exitImage = image;
                }
            }
            //_hpBar = Object.FindObjectOfType<Image>();
        }
        public void Display(int value)
        {
            //_point += value;
            //_text.text = $"Вы набрали: {_point}";

            _hpBar.fillAmount += value / _maxHp;

            //Log("HP: " + _hpBar.fillAmount);
        }

        public void DisplayKey()
        {
            _keyImage.fillAmount = 1.0f;
        }

        public void DisplayWin()
        {
            _exitImage.fillAmount = 1.0f;
            Time.timeScale = 0;
        }

        #endregion
    }
}
