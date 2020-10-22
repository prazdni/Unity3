using UnityEngine;

namespace MyLabyrinth
{
    public class GameController : MonoBehaviour
    {
        #region Fields

        [SerializeField] private BonusesContainer _bonusesContainer;

        private AllExecutableObjects _executableObjects;
        
        #endregion


        #region UnityMethods

        private void Awake()
        {
            _executableObjects = new AllExecutableObjects(_bonusesContainer);
            
            var bridges = new AllBridges(_executableObjects);
        }

        private void Update()
        {
            for (int i = 0; i < _executableObjects.Count; i++)
            {
                var interactiveObject = _executableObjects[i];
                
                if (interactiveObject is InteractiveObject interactive)
                {
                    if (!interactive.IsInteractable())
                    {
                        interactive.ObjectTransform.gameObject.SetActive(false);
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

