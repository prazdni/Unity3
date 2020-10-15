using System;
using UnityEngine;

namespace MyLabyrinth
{
    public class Timer : IExecute
    {
        private float _timerMaxValue;
        private float _timerMinValue;
        private float _currentTime;
        
        private AllExecutableObjects _executableObjects;
        
        public float CurrentTime
        {
            get => _currentTime;
        }

        public bool IsTimerStopped
        {
            get => !_isTimeStarted;
        }

        private bool _isTimeStarted = false;

        public Timer(AllExecutableObjects listOfAllExecutableObjects, float timerMinValue = 0, float timerMaxValue = 1)
        {
            _timerMaxValue = timerMaxValue;
            _timerMinValue = timerMinValue;

            _currentTime = _timerMaxValue;
            
            listOfAllExecutableObjects.AddExecutableObject(this);
        }

        public void StartTimeCount()
        {
            _isTimeStarted = true;
        }

        public void RestartTimeCount()
        {
            _currentTime = _timerMaxValue;
            StartTimeCount();
        }

        public void StopTimeCount()
        {
            _isTimeStarted = false;
        }

        public void ResetTimeCount()
        {
            _currentTime = _timerMaxValue;
        }

        public void Execute()
        {
            if (_isTimeStarted)
            {
                _currentTime -= Time.deltaTime;
                
                if (_currentTime < _timerMinValue)
                {
                    _currentTime = _timerMinValue;
                }
            }
        }
    }
}