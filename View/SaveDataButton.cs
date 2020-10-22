using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace MyLabyrinth
{
    public sealed class SaveDataButton : MonoBehaviour
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
        }

        #endregion
    }
}

