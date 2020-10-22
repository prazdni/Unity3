using UnityEngine;

namespace MyLabyrinth
{
    public class PlayerSpeedChanger
    {
        #region Fields

        private Timer _timer;
        private float _speed;
        private float _currentSpeed;
        private bool _shouldChangeSpeed = false;

        #endregion


        #region ClassLifeCycles

        public PlayerSpeedChanger(PlayerBase player, float time)
        {
            _timer = new Timer(0, time);
            _speed = player.Speed;
            _currentSpeed = _speed + 2.0f;
        }

        #endregion


        #region Methods

        public bool ShouldContinue()
        {
            return _shouldChangeSpeed;
        }

        public float ChangeSpeed(float tick)
        {
            float speed = _speed;
            
            _timer.TimerTick(tick);
            
            if (!_timer.IsTimerStopped)
            {
                speed = _currentSpeed;
            }
            else
            {
                _shouldChangeSpeed = false;
            }

            return speed;
        }

        public void StartChanging()
        {
            _shouldChangeSpeed = true;
            _timer.StartTimeCount();
        }

        #endregion
    }
}