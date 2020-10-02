using UnityEngine;
using DG.Tweening;

namespace MyLabyrinth
{
    public class CameraController : IExecute
    {
        #region Fields
        
        [SerializeField] private float _timer = 1.0f;

        private Transform _player;
        private Transform _mainCamera;
        private Vector3 _offset;
        private Camera _mainCameraCharacteristics;

        private float _field;
        private bool _isFieldChanged = false;
        private float _currentTimer;
        private float _fieldsOffset = 10.0f;

        #endregion

        #region ClassLifeCycles

        public CameraController(Transform player, Transform mainCamera)
        {
            _currentTimer = 0.0f;
            _player = player;
            _mainCamera = mainCamera;
            _mainCamera.LookAt(_player);
            _offset = _mainCamera.position - _player.position;
            _mainCameraCharacteristics = _mainCamera.gameObject.GetComponent<Camera>();
            _field = _mainCameraCharacteristics.fieldOfView;
        }

        #endregion
        
        
        #region Methods
        
        public void CameraShake(object o, PlayerEventArgs args)
        {
            //_isCameraShaking = true;
            Tweener tweener = DOTween.Shake(
                () => _mainCamera.position, pos => _mainCamera.position = pos, 
                1f, 0.5f, 5, 0.7f);
        }

        public void CameraChangeField(object o, PlayerEventArgs args)
        {
            _isFieldChanged = true;
        }

        #endregion


        #region IExecute
        
        public void Execute()
        {
            _mainCamera.position = _player.position + _offset;

            if (_isFieldChanged)
            {
                _mainCameraCharacteristics.fieldOfView = Mathf.Lerp(_field, _field + _fieldsOffset, _currentTimer * 0.5f);
                _currentTimer += Time.deltaTime;

                if (_currentTimer > _timer)
                {
                    _mainCameraCharacteristics.fieldOfView = Mathf.Lerp(_field, _field + _fieldsOffset, _currentTimer * 0.5f);
                    _isFieldChanged = false;
                }
            }
            else
            {
                if (_mainCameraCharacteristics.fieldOfView != _field)
                {
                    _mainCameraCharacteristics.fieldOfView = Mathf.Lerp(_field, _field + _fieldsOffset, _currentTimer * 0.5f);
                    _currentTimer -= Time.deltaTime;
                }
            }
        }
        
        #endregion
        
    }
}

