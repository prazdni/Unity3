using System;
using UnityEngine;
using UnityEngine.UI;

namespace MyLabyrinth
{
    public sealed class DisplayHealth : MonoBehaviour
    {
        #region Fields

        [SerializeField] private float _playerHP = 10.0f;
        private float _currentPlayerHP = 1.0f;
        private Text _finishGameLabel;
        private Image _healthBar;
        private RestartButton _restartButton;
        #endregion


        #region UnityMethods

        private void Start()
        {
            _finishGameLabel = GetComponentInChildren<Text>();
            _finishGameLabel.text = String.Empty;
            _healthBar = GetComponentInChildren<Image>();
            _healthBar.fillAmount = 1.0f;
            _restartButton = GetComponentInChildren<RestartButton>();
        }
        
        #endregion


        #region Methods

        public void HealOrDamage(object o, PlayerEventArgs args)
        {
            _currentPlayerHP = Mathf.Clamp(_currentPlayerHP + args.PlayerHPChange / _playerHP, 0.0f, 1.0f);

            _healthBar.fillAmount = _currentPlayerHP;
            
            if (_currentPlayerHP <= 0.0f)
            {
                _finishGameLabel.text = $"You lost! You were killed by {(o as BadBonus).gameObject.name} with {args.Color} color!";
                Time.timeScale = 0.0f;
                
                _restartButton.ActivateButton(true);
            }
            
            
        }

        #endregion
    }
}
