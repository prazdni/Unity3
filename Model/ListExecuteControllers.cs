namespace MyLabyrinth
{
    public class ListExecuteControllers
    {
        #region Fields
        
        private AllExecutableObjects _executableObjects;
        
        private CameraController _cameraController;

        #endregion


        #region Properties

        public CameraController CameraController => _cameraController;

        #endregion


        #region ClassLifeCycles

        public ListExecuteControllers(AllExecutableObjects listExecutableObjects, BonusesContainer container)
        {
            _executableObjects = listExecutableObjects;
            
            var bonusCreator = new BonusCreator(listExecutableObjects, container);
            
            _cameraController = new CameraController(Reference.PlayerBall.transform, Reference.MainCamera);
            AddExecutableController(_cameraController);
            AddExecutableController(Reference.PlayerBall);
            
            var inputController = new InputController(Reference.PlayerBall);
            AddExecutableController(inputController);
        }

        #endregion


        #region Methods

        private void AddExecutableController(IExecute execute)
        {
            _executableObjects.AddExecutableObject(execute);
        }

        #endregion
    }
}