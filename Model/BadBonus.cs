using System;
using UnityEngine;

namespace MyLabyrinth
{
    public class BadBonus : HealthBonus, IFly, IRotate
    {
        #region Fields

        public int Point;
        
        public event EventHandler<PlayerEventArgs> CaughtPlayer =
            delegate(object sender, PlayerEventArgs args) {  };
        
        public override event EventHandler<PlayerEventArgs> HealedOrDamagedPlayer = 
            delegate(object sender, PlayerEventArgs args) {  };

        private float _lengthFly;
        private float _speedRotation;

        #endregion


        #region UnityMethods

        private void Awake()
        {
            _lengthFly = UnityEngine.Random.Range(0.5f, 1.0f);
            _speedRotation = UnityEngine.Random.Range(10.0f, 50.0f);
        }

        #endregion


        #region Methods

        public void Rotate()
        {
            transform.Rotate(Vector3.up * (Time.deltaTime * _speedRotation), Space.World);
        }
        public void Fly()
        {
            transform.localPosition = new Vector3(transform.localPosition.x,
                Mathf.PingPong(Time.time, _lengthFly), transform.localPosition.z);
        }

        

        protected override void Interaction(Collider collider)
        {
            CaughtPlayer.Invoke(this, new PlayerEventArgs(_color, Point));
            HealedOrDamagedPlayer.Invoke(this, new PlayerEventArgs(_color, Point));
            
            collider.gameObject.GetComponent<Rigidbody>().AddExplosionForce(5.0f, 
                transform.position, 10.0f, 1.0f, ForceMode.Impulse);

            _isInteractable = false;
        }

        public override void Execute()
        {
            Rotate();
            Fly();
        }

        #endregion
    }
}

