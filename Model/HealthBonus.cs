using System;
using UnityEngine;

namespace MyLabyrinth
{
    public abstract class HealthBonus : InteractiveExecuteObject
    {
        #region Fields

        public abstract event EventHandler<PlayerEventArgs> HealedOrDamagedPlayer;

        #endregion


        #region Methods

        protected abstract override void Interaction(Collider coll);

        #endregion

        
        #region IExecute

        public abstract override void Execute();

        #endregion
    }
}