using System.Collections.Generic;
using UnityEngine;

namespace MyLabyrinth
{
    public class SavedDataController
    {
        private readonly SaveDataRepository _saveDataRepository;

        private SaveDataButton _savedData;
        private LoadDataButton _loadedData;
        
        public SavedDataController()
        {
            _saveDataRepository = new SaveDataRepository();
            Object.FindObjectOfType<SaveDataButton>().ButtonAction += SaveData;
            Object.FindObjectOfType<LoadDataButton>().ButtonAction += LoadData;

        }

        private void SaveData()
        {
            GameObject[] allSceneObjects;
            allSceneObjects = Object.FindObjectsOfType<GameObject>();
            Debug.Log(allSceneObjects.Length);
            //_saveDataRepository.Save();
        }

        private void LoadData()
        {
            //_saveDataRepository.Load
        }
        
    }
}