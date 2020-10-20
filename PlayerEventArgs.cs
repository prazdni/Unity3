using System;
using UnityEngine;

namespace MyLabyrinth
{
    public sealed class PlayerEventArgs : EventArgs
    {
        #region Properties
        
        public float PlayerHPChange { get; }
        
        public Color Color { get; }

        public bool IsDoorOpening { get; }

        #endregion


        #region Methods

        public PlayerEventArgs(Color color, float hpChange, bool isDoorOpening = false)
        {
            Color = color;
            PlayerHPChange = hpChange;
            IsDoorOpening = isDoorOpening;
        }

        #endregion
    }
}
