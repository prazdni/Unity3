using UnityEngine;

namespace MyLabyrinth
{
    public abstract class InteractiveObject : MonoBehaviour, IInteractable
    {
        #region Methods

        public abstract bool IsInteractable();

        #endregion
        
    }
}