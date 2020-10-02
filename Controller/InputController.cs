using UnityEngine;

namespace MyLabyrinth
{
    public sealed class InputController : IExecute 
    {
        #region Fields

        private readonly PlayerBase _playerBase;

        #endregion


        #region ClassLifeCycles

        public InputController(PlayerBase player)
        {
            _playerBase = player;
        }

        #endregion


        #region IExecute

        public void Execute()
        {
            _playerBase.Move(Input.GetAxis("Horizontal"), 0.0f, Input.GetAxis("Vertical"));
        }

        #endregion
    }
}