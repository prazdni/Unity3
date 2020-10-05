using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Object = UnityEngine.Object;
using Random = UnityEngine.Random;

namespace MyLabyrinth
{
    public class ListExecuteObjectsAndControllers : IEnumerator, IEnumerable
    {
        #region Fields

        public int Length => _interactiveBonuses.Count;
        
        private List<IExecute> _interactiveBonuses = new List<IExecute>();
        
        private CameraController _cameraController;
        private InputController _inputController;
        
        private int _index = -1;
        

        #endregion

        
        #region Properties

        public IExecute this [int index]
        {
            get => _interactiveBonuses[index];
            private set => _interactiveBonuses[index] = value;
        }

        public CameraController CameraController => _cameraController;

        public InputController InputController => _inputController;

        #endregion

        
        #region ClassLifeCycles

        public ListExecuteObjectsAndControllers()
        {
            SetRandomBonuses();

            AddExecuteBonuses();

            AddExecuteControllers();
        }

        #endregion
        
        
        #region Methods

        private void SetRandomBonuses()
        {
            var bonuses = Object.FindObjectsOfType<Bonus>();
            
            for (int i = 0; i < bonuses.Length; i++)
            {
                var randBonusType = Random.Range(0, 3);
                var randBuffType = Random.Range(1, 5);
                
                switch (randBonusType)
                {
                    case 0:
                        bonuses[i].gameObject.AddComponent<BadBonus>()
                            .BonusValue = -randBuffType;
                        break;
                    case 1:
                        bonuses[i].gameObject.AddComponent<GoodBonus>()
                            .BonusValue = randBuffType;
                        break;
                    case 2:
                        bonuses[i].gameObject.AddComponent<SpeedBonus>()
                            .BonusValue = randBuffType;
                        break;
                }
            }
        }
        
        private void AddExecuteBonuses()
        {
            var interactiveObjects = Object.FindObjectsOfType<InteractiveBonus>();
            
            for (int i = 0; i < interactiveObjects.Length; i++)
            {
                AddExecuteBonus(interactiveObjects[i]);
            }
        }
        
        public void AddExecuteBonus(IExecute execute)
        {
            _interactiveBonuses.Add(execute);
        }

        public void RemoveExecuteBonus(int index)
        {
            _interactiveBonuses.RemoveAt(index);
        }
        
        private void AddExecuteControllers()
        {
            var reference = new Reference();
            
            _cameraController = new CameraController(reference.PlayerBall.transform, reference.MainCamera.transform);
            AddExecuteBonus(_cameraController);
            AddExecuteBonus(reference.PlayerBall);
            
            _inputController = new InputController(reference.PlayerBall);
            AddExecuteBonus(_inputController);
            
            var uiController = new UIController(this);
        }

        #endregion


        #region IEnumerator

        public object Current => _interactiveBonuses[_index];
        
        public bool MoveNext()
        {

            if (_index == _interactiveBonuses.Count - 1)
            {
                Reset();
                return false;
            }

            _index++;
            return true;
        }
        
        public void Reset() => _index = -1;

        #endregion


        #region IEnumerable

        public IEnumerator GetEnumerator()
        {
            return this;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        #endregion
    }
}
