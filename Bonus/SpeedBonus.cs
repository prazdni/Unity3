using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace MyLabyrinth
{
    public sealed class SpeedBonus : Bonus, IFlick, IRotate
    {
        #region Fields

        private Material _material;
        
        private float _speedRotation;

        #endregion


        #region ClassLifeCycles

        public SpeedBonus(Transform objectTransform)
        {
            _objectTransform = objectTransform;
            
            objectTransform.gameObject.GetComponent<BonusCharacteristics>().SetBonus(this);
            
            _material = _objectTransform.gameObject.GetComponentInChildren<Renderer>().material;
            
            _speedRotation = Random.Range(10.0f, 50.0f);
        }

        #endregion


        #region IBonus
        
        public override event EventHandler<PlayerEventArgs> OnInteraction = (sender, args) => { };
        
        public override void Interaction(Transform interactedObject)
        {
            _isInteractable = false;
            
            OnInteraction.Invoke(this, new PlayerEventArgs(0, _isInteractable));

            var ball = interactedObject.GetComponent<PlayerBase>();

            ball.SpeedChanger.StartChanging();
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
            
            _objectTransform.gameObject.SetActive(_isInteractable);
        }

        #endregion
        
        
        #region IExecute

        public override void Execute()
        {
            Flick();
            Rotate();
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
            _objectTransform.Rotate(Vector3.up * (Time.deltaTime * _speedRotation), Space.World);
        }

        #endregion
    }
}
