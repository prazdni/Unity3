using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace MyLabyrinth
{
    public sealed class LoadDataButton : MonoBehaviour
    {
        #region Fields

        public UnityAction ButtonAction = () => { };
        private Button _button;

        #endregion


        #region UnityMethods

        private void Start()
        {
            _button = GetComponent<Button>();
            _button.onClick.AddListener(ButtonAction);
            _button.interactable = false;
        }

        #endregion


        #region Methods

        public void SetButtonActive()
        {
            _button.interactable = true;
        }

        #endregion
    }
}