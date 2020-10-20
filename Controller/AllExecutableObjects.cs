using System.Collections.Generic;

namespace MyLabyrinth
{
    public class AllExecutableObjects
    {
        private ListExecuteBonuses _executeBonuses;
        private ListExecuteControllers _executeControllers;
        private List<IExecute> _restListOfExecutableObjects;

        public int ExecutableObjectsCount =>
            _executeBonuses.Length + _executeControllers.Length + _restListOfExecutableObjects.Count;
        
        public CameraController CameraController => _executeControllers.CameraController;

        public InputController InputController => _executeControllers.InputController;

        public IExecute this[int value]
        {
            get
            {
                IExecute currentObject;
                
                if (value < _executeBonuses.Length)
                {
                    currentObject = _executeBonuses[value];
                }
                else
                {
                    if (_executeBonuses.Length <= value && value < _executeBonuses.Length + _executeControllers.Length)
                    {
                        currentObject = _executeControllers[value - _executeBonuses.Length];
                    }
                    else
                    {
                        currentObject =
                            _restListOfExecutableObjects[value - _executeBonuses.Length - _executeControllers.Length];
                    }
                    
                }

                return currentObject;
            }
        }
        public AllExecutableObjects()
        {
            _restListOfExecutableObjects = new List<IExecute>();
            _executeBonuses = new ListExecuteBonuses(this);
            _executeControllers = new ListExecuteControllers(this);
        }

        public void AddExecutableObject(IExecute execute)
        {
            if (execute is InteractiveObject)
            {
                AddExecutableBonus(execute);
            }
            else
            {
                if (execute is BaseController)
                {
                    AddExecutableController(execute);
                }
                else
                {
                    AddExecutalbeObject(execute);
                }
            }
        }

        private void AddExecutableBonus(IExecute executeBonus)
        {
            _executeBonuses.AddExecuteBonus(executeBonus);
        }
        
        private void AddExecutableController(IExecute executeController)
        {
            _executeBonuses.AddExecuteBonus(executeController);
        }

        private void AddExecutalbeObject(IExecute executeObject)
        {

            _restListOfExecutableObjects.Add(executeObject);
        }
    }
}