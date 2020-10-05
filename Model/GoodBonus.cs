using System;
using UnityEngine;
using Random = UnityEngine.Random;


namespace MyLabyrinth
{
    public sealed class GoodBonus : HealthBonus, IFly, IFlick, IExecute
    {
        #region Fields
        
        public override event EventHandler<PlayerEventArgs> HealedOrDamagedPlayer = 
            delegate(object sender, PlayerEventArgs args) {  };

        private Material _material;

        private float _lengthFly;

        #endregion

        
        #region UnityMethods

        private void Awake()
        {
            TypeOfBonus = BonusType.GoodBonus;
            _material = GetComponent<Renderer>().material;
            _lengthFly = Random.Range(0.5f, 1.0f);
        }

        #endregion


        #region Methods

        protected override void Interaction(Collider collider)
        {
            HealedOrDamagedPlayer.Invoke(this, new PlayerEventArgs(_color, BonusValue));
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


        #region IFly

        public void Fly()
        {
            transform.localPosition = new Vector3(transform.localPosition.x, 
                Mathf.PingPong(Time.time, _lengthFly), transform.localPosition.z);
        }

        #endregion



        #region IExecute

        public override void Execute()
        {
            Flick();
            Fly();
        }

        #endregion
    }
}

