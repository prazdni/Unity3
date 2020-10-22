using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace MyLabyrinth
{
    public static class Reference
    {
        #region Fields

        private static PlayerBall _playerBall;
        private static Camera _mainCamera;
        private static Transform _bonus;
        
        #endregion

        
        #region Properties

        public static PlayerBall PlayerBall
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

        public static Camera MainCamera
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

        public static Transform Bonus
        {
            get
            {
                if (_bonus == null)
                {
                    _bonus = Resources.Load<Transform>("Bonus");
                }

                return _bonus;
            }
        }

        #endregion
    }
}