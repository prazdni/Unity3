using System;
using UnityEngine;
using UnityEngine.UI;

namespace MyLabyrinth
{
    public class GameController : MonoBehaviour
    {
        #region Fields

        private AllExecutableObjects _executableObjects;

        private AllBridges _bridges;
        
        #endregion


        #region UnityMethods

        private void Awake()
        {
            _executableObjects = new AllExecutableObjects();
            
            _bridges = new AllBridges(_executableObjects);
        }

        private void Update()
        {
            for (int i = 0; i < _executableObjects.ExecutableObjectsCount; i++)
            {
                var interactiveObject = _executableObjects[i];
                
                if (interactiveObject is InteractiveBonus interactive)
                {
                    if (!interactive.IsInteractable())
                    {
                        interactive.gameObject.SetActive(false);
                        //Destroy(interactive.gameObject);
                        //_executeObjectsAndControllers.RemoveExecuteBonus(i);
                        continue;
                    }
                }

                interactiveObject.Execute();
            }
        }
        
        #endregion
    }
}

