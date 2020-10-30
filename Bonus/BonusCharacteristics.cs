using UnityEngine;
using Random = UnityEngine.Random;

namespace MyLabyrinth
{
    public sealed class BonusCharacteristics : MonoBehaviour
    {
        #region Fields
        
        private IBonus _bonus;

        private Color _color;
        
        #endregion
        

        #region Properties

        public BonusType TypeOfBonus => _bonus.GetBonusType();

        #endregion


        #region UnityMethods

        private void Start()
        {
            _color = Random.ColorHSV();
            
            if (TryGetComponent(out Renderer renderer))
            {
                renderer.material.color = _color;
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                _bonus.Interaction(other.transform);
            }
        }

        #endregion

        
        #region Methods

        public void SetBonus(IBonus bonus)
        {
            _bonus = bonus;
        }

        public void Deconstruct(out BonusType bonusType, out Color color) =>
            (bonusType, color) = (_bonus.GetBonusType(), _color);

        #endregion
    }
}