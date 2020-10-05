using System;
using UnityEngine;
using UnityEngine.UI;

namespace MyLabyrinth
{
    public class GameController : MonoBehaviour, IDisposable
    {
        #region Fields
        
        private ListExecuteObjectsAndControllers _executeObjectsAndControllers;
        
        private CameraController _cameraController;
        private InputController _inputController;

        #endregion


        #region UnityMethods

        private void Awake()
        {
            _executeObjectsAndControllers = new ListExecuteObjectsAndControllers();
            _cameraController = _executeObjectsAndControllers.CameraController;
            
            // var reference = new Reference();
            //
            //_inputController = _executeObjects.InputController;
            // _cameraController = new CameraController(reference.PlayerBall.transform, reference.MainCamera.transform);
            // _executeObjects.AddExecuteBonus(_cameraController);
            // _executeObjects.AddExecuteBonus(reference.PlayerBall);
            //
            // _inputController = new InputController(reference.PlayerBall);
            // _executeObjects.AddExecuteBonus(_inputController);
            //
            // var uiController = new UIController(_executeObjects);
            
            for (int i = 0; i < _executeObjectsAndControllers.Length; i++)
            {
                var interactiveObject = _executeObjectsAndControllers[i];
                
                if (interactiveObject is BadBonus badBonus)
                {
                    badBonus.CaughtPlayer +=
                        _executeObjectsAndControllers.CameraController.CameraShake;
                }

                if (interactiveObject is SpeedBonus speedBonus)
                {
                    speedBonus.ChangeSpeed += 
                        _executeObjectsAndControllers.CameraController.CameraChangeField;
                }
            }
        }

        private void Update()
        {
            for (int i = 0; i < _executeObjectsAndControllers.Length; i++)
            {
                var interactiveObject = _executeObjectsAndControllers[i];
                
                if (interactiveObject is InteractiveBonus interactive)
                {
                    if (!interactive.IsInteractable())
                    {
                        //interactive.gameObject.SetActive(false);
                        Destroy(interactive.gameObject);
                        _executeObjectsAndControllers.RemoveExecuteBonus(i);
                        continue;
                    }
                }

                interactiveObject.Execute();
            }
        }
        
        #endregion


        #region IDisposable

        public void Dispose()
        {
            for (int i = 0; i < _executeObjectsAndControllers.Length; i++)
            {

                var interactiveObject = _executeObjectsAndControllers[i];

                if (interactiveObject is BadBonus badBonus)
                {
                    badBonus.CaughtPlayer -=
                        _cameraController.CameraShake;;
                }

                if (interactiveObject is SpeedBonus speedBonus)
                {
                    speedBonus.ChangeSpeed -= _cameraController.CameraChangeField;
                }
                //удаление в ListExecuteObjects
            }
        }

        #endregion
    }
}

