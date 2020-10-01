using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace MyLabyrinth
{
    public sealed class SpeedBonus : InteractiveExecuteObject, IFlick, IRotate, IExecute
    {
        #region Fields

        public int Boost;
        public event EventHandler<PlayerEventArgs> ChangeSpeed =
            delegate(object sender, PlayerEventArgs args) {  };
        private Material _material;

        private float _speedRotation;
        private float _lengthFly;
        
        #endregion


        #region UnityMethods

        private void Awake()
        {
            _material = GetComponent<Renderer>().material;
            _lengthFly = Random.Range(0.5f, 1.0f);
            _speedRotation = Random.Range(10.0f, 50.0f);
        }

        #endregion


        #region Methods

        protected override void Interaction(Collider collider)
        {
            ChangeSpeed.Invoke(this, new PlayerEventArgs(_color, 0.0f));
            collider.gameObject.GetComponent<PlayerBall>().ChangeSpeed(Boost);

            _isInteractable = false;
        }

        public void Flick()
        {
            _material.color = new Color(_material.color.r, _material.color.g,
                _material.color.b, Mathf.PingPong(Time.time, 1.0f));
        }
        public void Rotate()
        {
            
            transform.Rotate(Vector3.up * (Time.deltaTime * _speedRotation), Space.World);
        }

        public override void Execute()
        {
            
            Flick();
            Rotate();
        }

        #endregion
    }
}
