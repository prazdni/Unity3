using System.Collections.Generic;
using UnityEngine;


namespace MyLabyrinth
{
    public sealed class PlayerBall : PlayerBase, IExecute
    {
        #region Fields

        private Rigidbody _rigidbody;
        
        private float _currentSpeed;
        private float _timer = 3.0f;
        private float _speedTimer;

        #endregion

        
        #region UnityMethods

        private void Start()
        {
            _rigidbody = GetComponent<Rigidbody>();
            _currentSpeed = _speed;
            _speedTimer = _timer;
        }

        #endregion

        
        #region Methods

        public override void Move(float x, float y, float z)
        {
            Vector3 movement = new Vector3(x, 0.0f, z);

            _rigidbody.AddForce(movement * _speed);
        }

        public void ChangeSpeed(float speedOffest)
        {
            _speed = _currentSpeed;

            _speedTimer = _timer;
            _speedTimer -= Time.deltaTime;

            _speed += speedOffest;
        }

        #endregion

        
        #region IExecute

        public void Execute()
        {
            if (_speedTimer != _timer)
            {
                _speedTimer -= Time.deltaTime;

                if (_speedTimer <= 0.0f)
                {
                    _speedTimer = _timer;
                    _speed = _currentSpeed;
                }
            }
        }

        #endregion
    }
}
