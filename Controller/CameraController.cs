﻿using System;
using UnityEngine;

namespace MyLabyrinth
{
    public class CameraController : IExecute
    {
        #region Fields
        
        private readonly Transform _player;
        private readonly Transform _mainCamera;
        private readonly Vector3 _offset;

        private CameraShaker _cameraShaker;
        private FieldChanger _fieldChanger;
        
        #endregion

        
        #region ClassLifeCycles

        public CameraController(Transform player, Camera mainCamera)
        {
            var cameraTransform = mainCamera.transform;
            
            _cameraShaker = new CameraShaker(cameraTransform);
            _fieldChanger = new FieldChanger(mainCamera);
            
            _player = player;
            _mainCamera = cameraTransform;
            _mainCamera.LookAt(_player);
            _offset = _mainCamera.position - _player.position;
        }

        #endregion
        
        
        #region Methods

        public void OnInteraction(object o, PlayerEventArgs args)
        {
            if (o is BadBonus && !args.IsLoading)
            {
                _cameraShaker.ShakeCamera();
            }

            if (o is SpeedBonus && !args.IsLoading)
            {
                _fieldChanger.ChangeField();
            }
        }

        #endregion


        #region IExecute
        
        public void Execute()
        {
            _mainCamera.position = _player.position + _offset;

            if (_fieldChanger.ShouldChangeField())
            {
                _fieldChanger.ChangeFieldProcessing(Time.deltaTime);
            }
        }
        
        #endregion
        
    }
}

