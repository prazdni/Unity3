using System;
using UnityEngine;
using UnityEngine.UI;
using Object = UnityEngine.Object;

namespace MyLabyrinth
{
    public sealed class ExitDoor : InteractiveObject, IConnectUIRestart
    {
        #region Fields

        public event EventHandler<PlayerEventArgs> OnEnter;
        
        private RestartButton _restartButton;
        private Collider _collider;

        #endregion

        
        #region UnityMethods

        private void Awake()
        {
            _collider = GetComponent<Collider>();
            _collider.isTrigger = false;
            _restartButton = FindObjectOfType<RestartButton>();
        }
        
        private void OnTriggerEnter(Collider other)
        {
            print("You won!");
            var displayWin = Object.FindObjectOfType<DisplayWin>();
            OnEnter.Invoke(this, new PlayerEventArgs(Color.cyan, 0.0f));
            _restartButton.ActivateButton(true);
        }
        
        #endregion


        #region Methods

        public override bool IsInteractable()
        {
            return _collider.isTrigger;
        }

        #endregion
        
        
        #region IConnectUIRestart

        public void Open(bool isOpened)
        {
            _collider.isTrigger = isOpened;
        }

        #endregion
    }
}
