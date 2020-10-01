using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Object = UnityEngine.Object;

namespace MyLabyrinth
{
    public sealed class ListExecuteObjects : IEnumerator, IEnumerable
    {
        public int Length => _interactiveObjects.Count;
        
        private List<IExecute> _interactiveObjects = new List<IExecute>();

        private InteractiveExecuteObject _current;

        private int _index = -1;

        public object Current => _interactiveObjects[_index];

        public IExecute this [int index]
        {
            get => _interactiveObjects[index];
            private set => _interactiveObjects[index] = value;
        }
        
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

        public void AddExecuteObject(IExecute execute)
        {
            _interactiveObjects.Add(execute);
        }

        public void RemoveExecuteObject(int index)
        {
            _interactiveObjects.RemoveAt(index);
        }

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

        public IEnumerator GetEnumerator()
        {
            return this;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        //private IEnumerator GetEnumerator()
        //{
        //    return this;
        //}
    }
}
