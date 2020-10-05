using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace MyLabyrinth
{
    public class Reference
    {
        #region Fields

        private PlayerBall _playerBall;
        private Camera _mainCamera;
        private GameObject _bonuse;
        private GameObject _endGame;
        private Canvas _canvas;
        private List<InteractiveBonus> _bonusCubes;
        
        #endregion

        #region Properties

        public PlayerBall PlayerBall
        {
            get
            {
                if (_playerBall == null)
                {
                    var gameObject = Resources.Load<PlayerBall>("Player");
                    _playerBall = Object.Instantiate(gameObject);
                }

                return _playerBall;
            }
        }

        public Camera MainCamera
        {
            get
            {
                if (_mainCamera == null)
                {
                    _mainCamera = Camera.main;
                }

                return _mainCamera;
            }
        }

        #endregion
    }
}