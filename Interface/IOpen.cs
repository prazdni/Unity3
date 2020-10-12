namespace MyLabyrinth
{
    public interface IOpen
    {
        bool IsOpened { get; set; }
        void Open(bool isOpened, IView view);
    }
}