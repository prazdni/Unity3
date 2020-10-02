using System;
using UnityEngine;

namespace MyLabyrinth
{
    public sealed class PlayerEventArgs : EventArgs
    {
        #region Fields

        public float PlayerHPChange { get; }

        #endregion


        #region Properties

        public Color Color { get; }

        #endregion


        #region Methods

        public PlayerEventArgs(Color color, float hpChange)
        {
            Color = color;
            PlayerHPChange = hpChange;
        }

        #endregion
    }
}
