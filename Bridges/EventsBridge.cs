using UnityEngine;

namespace MyLabyrinth
{
    public sealed class EventsBridge
    {
        #region Fields

        private AllExecutableObjects _executableObjects;

        #endregion


        #region ClassLifeCycles

        public EventsBridge(AllExecutableObjects listExecutableObjects)
        {
            _executableObjects = listExecutableObjects;
            
            for (int i = 0; i < _executableObjects.Count; i++)
            {
                var interactiveObject = _executableObjects[i];
                
                if (interactiveObject is BadBonus || interactiveObject is SpeedBonus)
                {
                    (interactiveObject as Bonus).OnInteraction +=
                        _executableObjects.CameraController.OnInteraction;
                }

                if (interactiveObject is KeyBonus keyBonus)
                {
                    var door = Object.FindObjectOfType<ExitDoor>();
                    keyBonus.OnInteraction += door.OpenTheDoor;
                }
            }
        }

        #endregion
        
        
        #region IDisposable

        public void Dispose()
        {
            for (int i = 0; i < _executableObjects.Count; i++)
            {

                var interactiveObject = _executableObjects[i];

                if (interactiveObject is BadBonus || interactiveObject is SpeedBonus)
                {
                    (interactiveObject as Bonus).OnInteraction -=
                        _executableObjects.CameraController.OnInteraction;
                }
                
                if (interactiveObject is KeyBonus keyBonus)
                {
                    var door = Object.FindObjectOfType<ExitDoor>();
                    keyBonus.OnInteraction -= door.OpenTheDoor;
                }
            }
        }

        #endregion
    }
}