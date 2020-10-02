using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Object = UnityEngine.Object;

namespace MyLabyrinth
{
    public sealed class ListExecuteObjects : IEnumerator, IEnumerable
    {
        #region Fields

        public int Length => _interactiveObjects.Count;
        
        private List<IExecute> _interactiveObjects = new List<IExecute>();
        
        private int _index = -1;

        #endregion

        
        #region Properties

        public IExecute this [int index]
        {
            get => _interactiveObjects[index];
            private set => _interactiveObjects[index] = value;
        }

        #endregion

        #region ClassLifeCycles

        public ListExecuteObjects()
        {
            var interactiveObjects = Object.FindObjectsOfType<InteractiveExecuteObject>();

            for (int i = 0; i < interactiveObjects.Length; i++)
            {
                if (interactiveObjects[i] is IExecute interactiveObject)
                {
                    AddExecuteObject(interactiveObject);
                }
            }
        }

        #endregion
        
        
        #region Methods

        public void AddExecuteObject(IExecute execute)
        {
            _interactiveObjects.Add(execute);
        }

        public void RemoveExecuteObject(int index)
        {
            _interactiveObjects.RemoveAt(index);
        }

        #endregion


        #region IEnumerator

        public object Current => _interactiveObjects[_index];
        
        public bool MoveNext()
        {

            if (_index == _interactiveObjects.Count - 1)
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
