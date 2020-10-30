using System;
using UnityEngine;
using Random = UnityEngine.Random;


namespace MyLabyrinth
{
    public sealed class GoodBonus : HealthBonus, IFly, IFlick
    {
        #region Fields

        private Material _material;

        private float _lengthFly;

        #endregion


        #region ClassLifeCycles

        public GoodBonus(Transform objectTransform)
        {
            _healthChange = Random.Range(0.1f, 0.5f);
            
            _objectTransform = objectTransform;
            
            objectTransform.gameObject.GetComponent<BonusCharacteristics>().SetBonus(this);

            _material = _objectTransform.gameObject.GetComponentInChildren<Renderer>().material;
            
            _lengthFly = Random.Range(0.5f, 1.0f);
        }

        #endregion
        
        
        #region IBonus

        public override event EventHandler<PlayerEventArgs> OnInteraction = (sender, args) => { };
        
        public override Transform ObjectTransform => _objectTransform;
        
        public override void Interaction(Transform interactedObject)
        {
            _isInteractable = false;
            
            var player = interactedObject.GetComponent<PlayerBall>();
            
            OnInteraction.Invoke(this, new PlayerEventArgs(player.Health + _healthChange, _isInteractable));
        }

        #endregion


        #region IInteractable

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
            Flick();
            Fly();
        }

        #endregion


        #region IFlick

        public void Flick()
        {
            _material.color = new Color(_material.color.r, _material.color.g,
                _material.color.b, Mathf.PingPong(Time.time, 1.0f));
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

