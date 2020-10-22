using UnityEngine;

namespace MyLabyrinth
{
    public abstract class InteractiveObject : IInteractable
    {
        #region Fields

        protected Transform _objectTransform;

        #endregion
        

        #region IInteractable

        public abstract Transform ObjectTransform { get; }
        
        public abstract bool IsInteractable();

        public abstract void SetInteractable(bool interactable);

        #endregion
    }
}