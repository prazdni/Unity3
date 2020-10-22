using System;
using UnityEngine;

namespace MyLabyrinth
{
    [Serializable]
    public class BonusData
    {
        #region Fields

        [SerializeField] private Vector3 _spawnPoint;
        
        [SerializeField] private BonusType _bonusType;

        #endregion


        #region Properties

        public Vector3 SpawnPoint => _spawnPoint;

        public BonusType BonusType => _bonusType;

        #endregion
    }
}