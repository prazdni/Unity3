using System;
using UnityEngine;
using UnityEngine.UI;

namespace MyLabyrinth
{
    public class GameController : MonoBehaviour, IDisposable
    {
        #region Fields
        
        private ListExecuteObjects _interactiveObject;
        
        private CameraController _cameraController;
        private InputController _inputController;
        private UIController _uiController;

        #endregion


        #region UnityMethods

        private void Awake()
        {
            var reference = new Reference();

            _interactiveObject = new ListExecuteObjects();

            _cameraController = new CameraController(reference.PlayerBall.transform, reference.MainCamera.transform);
            _interactiveObject.AddExecuteObject(_cameraController);
            _interactiveObject.AddExecuteObject(reference.PlayerBall);
            
            _inputController = new InputController(reference.PlayerBall);
            _interactiveObject.AddExecuteObject(_inputController);

            _uiController = new UIController(_interactiveObject);
            
            for (int i = 0; i < _interactiveObject.Length; i++)
            {
                var interactiveObject = _interactiveObject[i];
                
                if (interactiveObject is BadBonus badBonus)
                {
                    badBonus.CaughtPlayer +=
                        _cameraController.CameraShake;
                }

                if (interactiveObject is SpeedBonus speedBonus)
                {
                    speedBonus.ChangeSpeed += _cameraController.CameraChangeField;
                }
            }
        }

        private void Update()
        {
            for (int i = 0; i < _interactiveObject.Length; i++)
            {
                var interactiveObject = _interactiveObject[i];
                
                if (interactiveObject is InteractiveExecuteObject interactive)
                {
                    if (!interactive.IsInteractable())
                    {
                        Destroy(interactive.gameObject);
                        _interactiveObject.RemoveExecuteObject(i);
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
            for (int i = 0; i < _interactiveObject.Length; i++)
            {

                var interactiveObject = _interactiveObject[i];

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

