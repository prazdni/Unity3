﻿using System;
using UnityEngine;
using Random = UnityEngine.Random;


namespace MyLabyrinth
{
    public abstract class InteractiveExecuteObject : InteractiveObject, IExecute
    {
        #region Fields

        protected bool _isInteractable = true;
        public float Timer { get; } = 0.0f;
        
        protected Color _color;
        private IExecute _executeImplementation;
        
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

        public abstract void Execute();
    }
}

