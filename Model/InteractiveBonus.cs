using System;
using UnityEngine;
using Random = UnityEngine.Random;


namespace MyLabyrinth
{
    public abstract class InteractiveBonus : InteractiveObject, IExecute
    {
        #region Fields

        public int BonusValue = default;
        protected bool _isInteractable = true;
        protected Color _color;
        private IExecute _executeImplementation;
        private BonusType _typeOfBonus = BonusType.None;
        
        public abstract event EventHandler<PlayerEventArgs> OnInteraction;

        #endregion


        #region Properties

        public float Timer { get; } = 0.0f;

        public BonusType TypeOfBonus
        {
            get => _typeOfBonus;
            protected set => _typeOfBonus = value;
        }

        #endregion

        
        #region UnityMethods

        private void Start()
        {
            _color = Random.ColorHSV();
            
            if (TryGetComponent(out Renderer renderer))
            {
                renderer.material.color = _color;
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (!IsInteractable() || !other.CompareTag("Player"))
            {
                return;
            }

            Interaction(other);
        }

        #endregion


        #region Methods

        protected abstract void Interaction( Collider coll );

        public override bool IsInteractable()
        {
            return _isInteractable;
        }

        #endregion

        
        #region IExecute

        public abstract void Execute();

        #endregion
    }
}

