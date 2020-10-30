using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace MyLabyrinth
{
    public sealed class BadBonus : HealthBonus, IFly, IRotate
    {
        #region Fields

        private float _speedRotation;
        private float _lengthFly;

        #endregion

        
        #region ClassLifeCycles

        public BadBonus(Transform objectTransform)
        {
            _healthChange = Random.Range(-0.5f, -0.1f);
            
            _objectTransform = objectTransform;
            
            objectTransform.gameObject.GetComponent<BonusCharacteristics>().SetBonus(this);
            
            _lengthFly = Random.Range(0.5f, 1.0f);
            _speedRotation = Random.Range(10.0f, 50.0f);
        }

        #endregion
        
        
        #region IBonus

        public override event EventHandler<PlayerEventArgs> OnInteraction = (sender, args) => { };
        
        public override void Interaction(Transform interactedObject)
        {
            _isInteractable = false;

            var player = interactedObject.GetComponent<PlayerBall>();
            
            OnInteraction.Invoke(this, new PlayerEventArgs(player.Health + _healthChange, _isInteractable));
            
            interactedObject.gameObject.GetComponent<Rigidbody>().AddExplosionForce(5.0f, 
                interactedObject.position, 10.0f, 1.0f, ForceMode.Impulse);
        }

        #endregion
        
        
        #region IInteractable

        public override Transform ObjectTransform => _objectTransform;
        
        public override bool IsInteractable()
        {
            return _isInteractable;
        }

        public override void SetInteractable(bool interactable)
        {
            _isInteractable = interactable;
            
            OnInteraction.Invoke(this, new PlayerEventArgs(1.0f, true));

            _objectTransform.gameObject.SetActive(_isInteractable);
        }

        #endregion


        #region IExecute

        public override void Execute()
        {
            Rotate();
            Fly();
        }

        #endregion


        #region IRotate

        public void Rotate()
        {
            _objectTransform.Rotate(Vector3.up * (Time.deltaTime * _speedRotation), Space.World);
        }

        #endregion


        #region IFly

        public void Fly()
        {
            _objectTransform.localPosition = new Vector3(_objectTransform.localPosition.x,
                Mathf.PingPong(Time.time, _lengthFly) + 0.5f, _objectTransform.localPosition.z);
        }

        #endregion
    }
}

