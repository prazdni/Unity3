using UnityEngine;

namespace MyLabyrinth
{
    public class FieldChanger
    {
        #region Fields

        private readonly Camera _mainCameraCharacteristics;
        private readonly Timer _timer;
        private readonly float _field;
        private float _fieldsOffset = 10.0f;
        private bool _isFieldChanged = false;

        #endregion


        #region ClassLifeCycles

        public FieldChanger(Camera mainCamera)
        {
            _timer = new Timer();

            _mainCameraCharacteristics = mainCamera;
            _field = _mainCameraCharacteristics.fieldOfView;
        }

        #endregion


        #region Methods

        public void ChangeField()
        {
            _timer.StartTimeCount();
            _isFieldChanged = true;
        }
        
        public bool ShouldChangeField()
        {
            return _isFieldChanged;
        }

        public void ChangeFieldProcessing(float tick)
        {
            if (_isFieldChanged)
            {
                if (!_timer.IsTimerStopped)
                {
                    _mainCameraCharacteristics.fieldOfView = Mathf.Lerp(_field, _field + _fieldsOffset,
                        Mathf.PingPong((1 - _timer.CurrentTime) * 2, 1));
                    
                    _timer.TimerTick(tick);
                }
                else
                {
                    _isFieldChanged = false;
                }
            }
        }
        
        #endregion
    }
}