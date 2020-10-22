using System;
using System.Collections.Generic;
using UnityEngine;

namespace MyLabyrinth
{
    [CreateAssetMenu(fileName = "Bonuses", menuName = "Objects/Bonuses", order = 0)]
    public class BonusesContainer : ScriptableObject
    {
        #region Fields

        [SerializeField] private List<BonusData> _interactableList;

        #endregion


        #region Properties

        public int BonusCount => _interactableList.Count;
        
        public BonusData this [int value]
        {
            get => _interactableList[value];
        }

        #endregion
    }
}