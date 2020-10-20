using System;
using UnityEngine;

namespace MyLabyrinth
{
    public abstract class HealthBonus : InteractiveBonus
    {

        #region Methods

        protected abstract override void Interaction(Collider coll);

        #endregion

        
        #region IExecute

        public abstract override void Execute();

        #endregion
    }
}