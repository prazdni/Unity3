using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace MyLabyrinth
{
    public sealed class SaveDataRepository
    {
        private readonly IData<SavedData> _data;
        private readonly IData<SavedData[]> _bonusesData;
        private const string _folderName = "dataSave";
        private const string _fileName = "data1.bat";
        private readonly string _path;

        public SaveDataRepository()
        {
            _bonusesData = new SerializableXMLData<SavedData[]>();
            _data = new XMLData();
            _path = Path.Combine(Application.dataPath, _folderName);
        }

        public void Save(GameObject player)
        {
            if (!Directory.Exists(_path))
                Directory.CreateDirectory(_path);

            var transform = player.transform;
            SavedData savedPlayer = new SavedData
            {
                Name = player.name,
                Position = transform.position,
                Rotation = transform.rotation.eulerAngles,
                IsEnabled = true
            };
            
            _data.Save(savedPlayer, Path.Combine(_path, _fileName));
        }
        
        public void Save(List<Bonus> bonuses)
        {
            SavedData[] bonusesData = new SavedData[bonuses.Count];
            for (int i = 0; i < bonusesData.Length; i++)
            {
                bonusesData[i] = new SavedData
                {
                    Name = bonuses[i].name, Position = bonuses[i].transform.position,
                    Rotation = bonuses[i].transform.rotation.eulerAngles, IsEnabled = true
                };
            }
            //var tmpData = new SerializableXMLData<SaveBonusesData>();
            
            if (!Directory.Exists(_path))
                Directory.CreateDirectory(_path);
            
            //SaveBonusesData bonusesData = new SaveBonusesData(bonuses);

            _bonusesData.Save(bonusesData, Path.Combine(_path, _fileName));
        }

        public void Load(GameObject player)
        {
            var file = Path.Combine(_path, _fileName);
            if (!File.Exists(file))
                return;

            var newPlayer = _data.Load(file);
            player.transform.position = newPlayer.Position;
            player.name = newPlayer.Name;
            player.transform.Rotate(newPlayer.Rotation.X, newPlayer.Rotation.Y, newPlayer.Rotation.Z);
            player.gameObject.SetActive(newPlayer.IsEnabled);
        }
        
        public void Load(List<Bonus> bonuses)
        {
            var file = Path.Combine(_path, _fileName);
            
            if (!File.Exists(file))
                return;
            
            var newBonusesData = _bonusesData.Load(file);
            
            for (int i = 0; i < newBonusesData.Length; i++)
            {
                bonuses[i].name = newBonusesData[i].Name;
                bonuses[i].transform.position = newBonusesData[i].Position;
                bonuses[i].transform.Rotate(newBonusesData[i].Rotation.X, newBonusesData[i].Rotation.Y,
                    newBonusesData[i].Rotation.Z);
                bonuses[i].gameObject.SetActive(newBonusesData[i].IsEnabled);
            }
        }
    } 
}

