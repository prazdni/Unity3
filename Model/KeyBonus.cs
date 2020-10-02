using System;
using UnityEngine;
using Object = UnityEngine.Object;
using Random = UnityEngine.Random;

namespace MyLabyrinth
{
    class KeyBonus : InteractiveExecuteObject, IFly, IFlick
    {
        #region Fields
        
        public event EventHandler<PlayerEventArgs> ShowKey =
            delegate(object sender, PlayerEventArgs args) {  };

        private Material _material;

        private float _lengthFly;

        #endregion


        #region UnityMethods

        private void Awake()
        {
            _material = GetComponent<Renderer>().material;
            _lengthFly = Random.Range(0.5f, 1.0f);
        }

        #endregion


        #region Methods

        protected override void Interaction(Collider collider)
        {
            var door = Object.FindObjectOfType<ExitDoor>();
            door.Open(true);

            ShowKey.Invoke(this, new PlayerEventArgs(_color, 0.0f));
            
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
