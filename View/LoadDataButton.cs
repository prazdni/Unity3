using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace MyLabyrinth
{
    public class LoadDataButton : MonoBehaviour
    {
        public UnityAction ButtonAction = () => { };
        private Button _button;

        private void Start()
        {
            _button = GetComponent<Button>();
            _button.onClick.AddListener(ButtonAction);
        }
    }
}