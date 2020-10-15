using UnityEngine;

namespace MyLabyrinth
{
    public class FieldChanger : IExecute
    {
        private readonly Camera _mainCameraCharacteristics;
        
        private Timer _timer;
        
        private float _fieldsOffset = 10.0f;
        private float _field;
        private bool _isFieldChanged = false;

        public FieldChanger(Transform player, Camera mainCamera, AllExecutableObjects listExecutableObjects)
        {
            _timer = new Timer(listExecutableObjects);

            _mainCameraCharacteristics = mainCamera;
            _field = _mainCameraCharacteristics.fieldOfView;
            listExecutableObjects.AddExecutableObject(this);
        }

        public void ChangeField()
        {
            _isFieldChanged = true;
        }

        public void Execute()
        {
            if (_isFieldChanged)
            {
                if (_timer.IsTimerStopped)
                {
                    _timer.StartTimeCount();
                }

                _mainCameraCharacteristics.fieldOfView = Mathf.Lerp(_field, _field + _fieldsOffset,
                    Mathf.PingPong((1 - _timer.CurrentTime) * 2, 1));

                if ((1 - _timer.CurrentTime) * 2 > 1)
                {
                    if (Mathf.Abs(_mainCameraCharacteristics.fieldOfView - _field) < 0.1)
                    {
                        _timer.StopTimeCount();
                        _mainCameraCharacteristics.fieldOfView = _field;
                        _isFieldChanged = false;
                    }
                }
                
            }
        }
    }
}