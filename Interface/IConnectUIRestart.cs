using System;

namespace MyLabyrinth
{
    public interface IConnectUIRestart
    {
        event EventHandler<PlayerEventArgs> OnAction;
    }
}
