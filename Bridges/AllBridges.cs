namespace MyLabyrinth
{
    public sealed class AllBridges
    {
        #region ClassLifeCycles

        public AllBridges(AllExecutableObjects listExecutableObjects)
        {
            var uiBridge = new UIBridge(listExecutableObjects);
            var dataBridge = new DataBridge(listExecutableObjects, uiBridge.HealthBar);
            var eventsBridge = new EventsBridge(listExecutableObjects);
        }

        #endregion
    }
}