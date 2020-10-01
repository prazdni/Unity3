using System;
using UnityEngine;

namespace MyLabyrinth
{
    public abstract class HealthBonus : InteractiveExecuteObject
    {
        public abstract event EventHandler<PlayerEventArgs> HealedOrDamagedPlayer;
        protected abstract override void Interaction(Collider coll);

        public abstract override void Execute();
    }
}