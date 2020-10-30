using UnityEngine;


namespace MyLabyrinth
{
    public abstract class PlayerBase : MonoBehaviour, IChangeSpeed, IInteractable
    {
        #region Fields

        [SerializeField] protected float _speed = 3.0f;
        
        public float Health = 1.0f;
        
        protected PlayerSpeedChanger _speedChanger;

        #endregion


        #region Properties

        public float Speed => _speed;

        #endregion


        #region Methods

        public abstract void Move(float x, float y, float z);
        
        #endregion
        
        
        #region IChangeSpeed

        public abstract PlayerSpeedChanger SpeedChanger { get; }

        #endregion


        #region IInteractable

        public abstract Transform ObjectTransform { get; }
        
        public abstract bool IsInteractable();

        public abstract void SetInteractable(bool interactable);

        #endregion
    }
}


