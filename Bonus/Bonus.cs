using System;
using UnityEngine;

namespace MyLabyrinth
{
    public abstract class Bonus : InteractiveObject, IBonus, IExecute
    {
        #region Fields
        
        public abstract event EventHandler<PlayerEventArgs> OnInteraction;

        protected bool _isInteractable = true; 
        
        protected BonusType _typeOfBonus = BonusType.None;

        #endregion


        #region IExecute

        public abstract void Execute();

        #endregion

        
        #region IBonus

        public BonusType GetBonusType()
        {
            return _typeOfBonus;
        }

        public void SetBonusType(BonusType type)
        {
            _typeOfBonus = type;
        }

        public abstract void Interaction(Transform interactedObject);

        #endregion
    }
}

