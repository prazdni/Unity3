using System;
using UnityEngine;
using Object = UnityEngine.Object;

namespace MyLabyrinth
{
    public sealed class ExitDoor : MonoBehaviour
    {
        #region Fields

        public event EventHandler<PlayerEventArgs> OnEnter = (sender, args) => { }; 
        
        #endregion


        #region UnityMethods

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                OnEnter.Invoke(this, new PlayerEventArgs(0, false));
            }
        }

        #endregion

        
        #region Methods

        public void OpenTheDoor(object o, PlayerEventArgs args)
        {
            gameObject.GetComponent<Collider>().isTrigger = true;
        }

        #endregion
    }
}
