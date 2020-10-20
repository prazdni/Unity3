namespace MyLabyrinth
{
    public class AllBridges
    {
        private DataBridge _dataBridge;
        private EventsBridge _eventsBridge;
        private UIBridge _uiBridge;

        public AllBridges(AllExecutableObjects listExecutableObjects)
        {
            _dataBridge = new DataBridge();
            _uiBridge = new UIBridge(listExecutableObjects);
            _eventsBridge = new EventsBridge(listExecutableObjects);
        }
    }
}