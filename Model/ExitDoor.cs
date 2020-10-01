using System;
using UnityEngine;
using UnityEngine.UI;
using Object = UnityEngine.Object;

namespace MyLabyrinth
{
    public sealed class ExitDoor : InteractiveObject, IConnectUIRestart
    {
        public event EventHandler<PlayerEventArgs> OnAction;
        private Collider _collider;
        private RestartButton _restartButton;
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
            OnAction.Invoke(this, new PlayerEventArgs(Color.cyan, 0.0f));
            _restartButton.ActivateButton(true);
        }
        public void Open(bool isOpened)
        {
            _collider.isTrigger = isOpened;
        }

        public override bool IsInteractable()
        {
            return _collider.isTrigger;
        }
    }
}
