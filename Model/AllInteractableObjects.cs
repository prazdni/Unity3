using System.Collections.Generic;

namespace MyLabyrinth
{
    public class AllInteractableObjects
    {
        #region Fields

        private List<IInteractable> _interactableObjects;

        #endregion



        #region Properties

        public List<IInteractable> InteractableObjects => _interactableObjects;

        #endregion


        #region ClassLifeCycles

        public AllInteractableObjects(AllExecutableObjects executableObjects)
        {
            _interactableObjects = new List<IInteractable>();
            
            for (int i = 0; i < executableObjects.Count; i++)
            {
                if (executableObjects[i] is IInteractable interactable)
                {
                    _interactableObjects.Add(interactable);
                }
            }
        }

        #endregion
    }
}