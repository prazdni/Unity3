using UnityEngine;


namespace MyLabyrinth
{
    public abstract class PlayerBase : MonoBehaviour
    {
        #region Fields

        [SerializeField] protected float _speed = 3.0f;
        
        #endregion


        #region Methods

        public abstract void Move(float x, float y, float z);
        
        #endregion
    }
}


