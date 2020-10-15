using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace MyLabyrinth
{
    public class DataBridge
    {
        private readonly DataRepository _dataRepository;

        private SaveDataButton _savedData;
        private LoadDataButton _loadedData;
        
        public DataBridge()
        {
            _dataRepository = new DataRepository();
            Object.FindObjectOfType<SaveDataButton>().ButtonAction += SaveBonusesData;
            Object.FindObjectOfType<LoadDataButton>().ButtonAction += LoadBonusesData;

        }

        private void SaveBonusesData()
        {
            var bonuses = Resources.FindObjectsOfTypeAll<Bonus>().ToList();
            _dataRepository.Save(bonuses);
        }

        private void LoadBonusesData()
        {
            var bonuses = Resources.FindObjectsOfTypeAll<Bonus>().ToList();
            _dataRepository.Load(bonuses);
        }
    }
}