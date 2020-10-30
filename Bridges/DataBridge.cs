using System.Collections.Generic;
using UnityEngine;

namespace MyLabyrinth
{
    public sealed class DataBridge
    {
        #region Fields
        
        private List<IInteractable> _listInteractableObjects;
        private AllInteractableObjects _allInteractableObjects;
        
        private readonly DataRepository _dataRepository;
        
        private SaveDataButton _savedData;
        private LoadDataButton _loadedData;

        #endregion


        #region ClassLifeCycles

        public DataBridge(AllExecutableObjects executableObjects, DisplayHealth healthBar)
        {
            _savedData = Object.FindObjectOfType<SaveDataButton>();
            _loadedData = Object.FindObjectOfType<LoadDataButton>();
            
            _dataRepository = new DataRepository();

            _allInteractableObjects = new AllInteractableObjects(executableObjects);

            _listInteractableObjects = _allInteractableObjects.InteractableObjects;

            _savedData.ButtonAction += SaveBonusesData;
            _savedData.ButtonAction += healthBar.RememberHealth;
            _savedData.ButtonAction += _loadedData.SetButtonActive;
            
            _loadedData.ButtonAction += LoadBonusesData;

        }

        #endregion


        #region Methods

        private void SaveBonusesData()
        { 
            _dataRepository.Save(_listInteractableObjects);
        }

        private void LoadBonusesData()
        {
            _dataRepository.Load(_listInteractableObjects);
        }

        #endregion
    }
}