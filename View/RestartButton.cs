using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace MyLabyrinth
{
    public sealed class RestartButton : MonoBehaviour
    {
        private Button _button;
        private Text _text;

        private void Start()
        {
            _button = GetComponent<Button>();
            _button.onClick.AddListener(
                () =>
                {
                    SceneManager.LoadScene(0);
                    Time.timeScale = 1.0f;
                });
            _text = _button.GetComponentInChildren<Text>();
            _text.text = String.Empty;
        }

        public void ActivateButton(bool isActive)
        {
            _button.interactable = isActive;
            
            _text.text = String.Empty;
            
            if (isActive)
            {
                _text.text = "Restart";
            }
        }
    }
}