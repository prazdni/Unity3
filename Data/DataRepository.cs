using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace MyLabyrinth
{
    public sealed class DataRepository
    {
        #region Fields

        private readonly IData<SavedData[]> _sceneObjectsData;
        
        private const string _folderName = "dataSave";
        private const string _fileName = "BonusesData.bat";
        
        private readonly string _path;

        #endregion


        #region ClassLifeCycles

        public DataRepository()
        {
            _sceneObjectsData = new SerializableXMLData<SavedData[]>();
            _path = Path.Combine(Application.dataPath, _folderName);
        }

        #endregion


        #region Methods

        public void Save(List<IInteractable> interactableObjects)
        {
            SavedData[] objectsData = new SavedData[interactableObjects.Count];
            
            for (int i = 0; i < objectsData.Length; i++)
            {
                objectsData[i] = InteractableToData(interactableObjects[i]);
            }

            if (!Directory.Exists(_path))
                Directory.CreateDirectory(_path);
            
            _sceneObjectsData.Save(objectsData, Path.Combine(_path, _fileName));
        }

        public void Load(List<IInteractable> interactableObjects)
        {
            var file = Path.Combine(_path, _fileName);

            if (!File.Exists(file))
                return;

            var newSceneObjectsData = _sceneObjectsData.Load(file);

            for (int i = 0; i < newSceneObjectsData.Length; i++)
            {
                DataToInteractable(interactableObjects[i], newSceneObjectsData[i]);
            }
        }

        private SavedData InteractableToData(IInteractable interactableObject)
        {
            var data = new SavedData
            {
                Name = interactableObject.ObjectTransform.name, Position = interactableObject.ObjectTransform.position,
                Rotation = interactableObject.ObjectTransform.rotation,
                IsEnabled = interactableObject.IsInteractable()
            };

            return data;
        }

        private void DataToInteractable(IInteractable interactableObject, SavedData data)
        {
            interactableObject.ObjectTransform.name = data.Name;
            interactableObject.ObjectTransform.position = data.Position;
            interactableObject.ObjectTransform.rotation = data.Rotation;
            interactableObject.SetInteractable(data.IsEnabled);
        }

        #endregion
    }
}