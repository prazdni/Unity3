using System.Collections.Generic;
using UnityEngine;

namespace MyLabyrinth
{
    public class AllExecutableObjects
    {
        #region Fields

        private ListExecuteControllers _executeControllers;

        private List<IExecute> _listOfExecutableObjects;

        #endregion


        #region Properties
        
        public CameraController CameraController => _executeControllers.CameraController;

        public int Count => _listOfExecutableObjects.Count;
        
        public IExecute this[int value]
        {
            get => _listOfExecutableObjects[value];
        }
        
        #endregion


        #region ClassLifeCycles

        public AllExecutableObjects(BonusesContainer bonusesContainer)
        {
            _listOfExecutableObjects = new List<IExecute>();
            
            _executeControllers = new ListExecuteControllers(this, bonusesContainer);
        }

        #endregion

        
        #region Methods

        public void AddExecutableObject(IExecute execute)
        {
            _listOfExecutableObjects.Add(execute);
        }

        #endregion
    }
}