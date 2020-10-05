using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace MyLabyrinth
{
    public sealed class SpeedBonus : InteractiveBonus, IFlick, IRotate, IExecute
    {
        #region Fields

        public event EventHandler<PlayerEventArgs> ChangeSpeed =
            delegate(object sender, PlayerEventArgs args) {  };
        
        private Material _material;
        
        private float _speedRotation;

        #endregion


        #region UnityMethods

        private void Awake()
        {
            TypeOfBonus = BonusType.SpeedBonus;
            _material = GetComponent<Renderer>().material;
            _speedRotation = Random.Range(10.0f, 50.0f);
        }

        #endregion


        #region Methods

        protected override void Interaction(Collider collider)
        {
            ChangeSpeed.Invoke(this, new PlayerEventArgs(_color, 0.0f));
            collider.gameObject.GetComponent<PlayerBall>().ChangeSpeed(BonusValue);

            _isInteractable = false;
        }

        #endregion
        
        
        #region IFlick

        public void Flick()
        {
            _material.color = new Color(_material.color.r, _material.color.g,
                _material.color.b, Mathf.PingPong(Time.time, 1.0f));
        }

        #endregion


        #region IRotate

        public void Rotate()
        {
            
            transform.Rotate(Vector3.up * (Time.deltaTime * _speedRotation), Space.World);
        }

        #endregion


        #region IExecute

        public override void Execute()
        {
            Flick();
            Rotate();
        }

        #endregion
    }
}
