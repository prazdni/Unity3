using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;


namespace MyLabyrinth
{
    public sealed class PlayerBall : PlayerBase, IExecute
    {
        #region Fields

        private Rigidbody _rigidbody;
        
        private PlayerSpeedChanger _speedChanger;
        
        private float _speedTimer = 2.0f;

        #endregion
        
        
        #region UnityMethods

        private void Start()
        {
            _rigidbody = GetComponent<Rigidbody>();
            _speedChanger = new PlayerSpeedChanger(this, _speedTimer);
        }

        #endregion


        #region Methods

        public override void Move(float x, float y, float z)
        {
            Vector3 movement = new Vector3(x, 0.0f, z);

            _rigidbody.AddForce(movement * _speed);
        }

        #endregion
        
        
        #region IChangeSpeed

        public override PlayerSpeedChanger SpeedChanger => _speedChanger;

        #endregion
        
        
        #region IInteractable

        public override Transform ObjectTransform => transform;
        
        public override bool IsInteractable()
        {
            return gameObject.activeSelf;
        }

        public override void SetInteractable(bool interactable)
        {
            gameObject.SetActive(interactable);
        }

        #endregion
        
        
        #region IExecute

        public void Execute()
        {
            if (_speedChanger.ShouldContinue())
            {
                _speed = _speedChanger.ChangeSpeed(Time.deltaTime);
            }
        }

        #endregion
    }
}
