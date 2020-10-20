using UnityEngine;

namespace MyLabyrinth
{
    public class EventsBridge
    {
        private AllExecutableObjects _executableObjects;
        
        public EventsBridge(AllExecutableObjects listExecutableObjects)
        {
            _executableObjects = listExecutableObjects;
            
            for (int i = 0; i < _executableObjects.ExecutableObjectsCount; i++)
            {
                var interactiveObject = _executableObjects[i];
                
                if (interactiveObject is BadBonus || interactiveObject is SpeedBonus)
                {
                    (interactiveObject as InteractiveBonus).OnInteraction +=
                        _executableObjects.CameraController.OnInteraction;
                }

                if (interactiveObject is KeyBonus keyBonus)
                {
                    var door = Object.FindObjectOfType<ExitDoor>();
                    keyBonus.OnInteraction += door.Open;
                }
            }
        }
        
        #region IDisposable

        public void Dispose()
        {
            for (int i = 0; i < _executableObjects.ExecutableObjectsCount; i++)
            {

                var interactiveObject = _executableObjects[i];

                if (interactiveObject is BadBonus || interactiveObject is SpeedBonus)
                {
                    (interactiveObject as InteractiveBonus).OnInteraction -=
                        _executableObjects.CameraController.OnInteraction;
                }
                //удаление в ListExecuteObjects
            }
        }

        #endregion
    }
}