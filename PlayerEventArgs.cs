using System;
using UnityEngine;

namespace MyLabyrinth
{
    public sealed class PlayerEventArgs : EventArgs
    {
        #region Properties
        
        public float PlayerHealth { get; }

        public bool IsDoorOpening { get; }
        
        public bool IsLoading { get; }

        #endregion


        #region Methods

        public PlayerEventArgs(float health, bool isLoading, bool isDoorOpening = false)
        {
            PlayerHealth = health;
            IsDoorOpening = isDoorOpening;
            IsLoading = isLoading;
        }

        #endregion
    }
}
