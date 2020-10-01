using System;
using UnityEngine;

namespace MyLabyrinth
{
    public sealed class PlayerEventArgs : EventArgs
    {
        public Color Color { get; }
        public float PlayerHPChange { get; }
        public PlayerEventArgs(Color color, float hpChange)
        {
            Color = color;
            PlayerHPChange = hpChange;
        }
    }
}
