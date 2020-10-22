using System;
using UnityEngine;

namespace MyLabyrinth
{
    public interface IBonus : IInteractable
    {
        event EventHandler<PlayerEventArgs> OnInteraction;
        
        BonusType GetBonusType();
        
        void SetBonusType(BonusType type);

        void Interaction(Transform interactedObject);
    }
}