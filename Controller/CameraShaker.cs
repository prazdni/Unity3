using DG.Tweening;
using UnityEngine;

namespace MyLabyrinth
{
    public class CameraShaker
    {
        private readonly Transform _mainCamera;
        private Tweener _tweener;
        
        public CameraShaker(Transform mainCamera)
        {
            _mainCamera = mainCamera;
            DOTween.Clear(true);
        }

        public void ShakeCamera()
        {
            _tweener = DOTween.Shake(
                () => _mainCamera.position, pos => _mainCamera.position = pos, 
                1f, 0.5f, 5, 0.7f);
        }
    }
}