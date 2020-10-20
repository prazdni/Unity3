using System.Collections.Generic;

namespace MyLabyrinth
{
    public class ListExecuteControllers
    {
        private AllExecutableObjects _executableObjects;
        
        private List<IExecute> _executableControllers;
        
        private CameraController _cameraController;
        private InputController _inputController;
        
        public IExecute this [int index]
        {
            get => _executableControllers[index];
            private set => _executableControllers[index] = value;
        }
        
        public int Length => _executableControllers.Count;
        
        public CameraController CameraController => _cameraController;

        public InputController InputController => _inputController;

        public ListExecuteControllers(AllExecutableObjects listExecutableObjects)
        {
            _executableObjects = listExecutableObjects;
            _executableControllers = new List<IExecute>();
            AddExecuteControllers();
        }
        
        public void AddExecuteControllers()
        {
            var reference = new Reference();
            
            _cameraController = new CameraController(reference.PlayerBall.transform, reference.MainCamera, _executableObjects);
            AddExecutableController(_cameraController);
            AddExecutableController(reference.PlayerBall);
            
            _inputController = new InputController(reference.PlayerBall);
            AddExecutableController(_inputController);
        }

        private void AddExecutableController(IExecute execute)
        {
            _executableControllers.Add(execute);
        }
    }
}