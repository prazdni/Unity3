using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Object = UnityEngine.Object;

namespace MyLabyrinth
{
    public sealed class UIBridge : IDisposable
    {
        
        #region Fields

        private readonly AllExecutableObjects _executableObjects;
        
        private DisplayHealth _displayHealth;
        private DisplayKey _displayKey;
        private DisplayWin _displayWin;
        private ExitDoor _exitDoor;

        #endregion


        #region Properties

        public DisplayHealth HealthBar => _displayHealth;

        #endregion

        
        #region ClassLifeCycles

        public UIBridge(AllExecutableObjects listExecutableObjects)
        {
            _displayHealth = Object.FindObjectOfType<DisplayHealth>();
            _displayKey = Object.FindObjectOfType<DisplayKey>();
            _displayWin = Object.FindObjectOfType<DisplayWin>();
            
            _executableObjects = listExecutableObjects;

            for (int i = 0; i < _executableObjects.Count; i++)
            {
                var interactiveObject = _executableObjects[i];

                switch (interactiveObject)
                {
                    case HealthBonus healthBonus:
                        healthBonus.OnInteraction += _displayHealth.HealOrDamage;
                        break;
                    case KeyBonus keyBonus:
                        keyBonus.OnInteraction += _displayKey.ShowKey;
                        break;
                }
            }

            _exitDoor = Object.FindObjectOfType<ExitDoor>();
            _exitDoor.OnEnter += _displayWin.ShowWin;
        }

        #endregion


        #region IDisposable

        public void Dispose()
        {
            for (int i = 0; i < _executableObjects.Count; i++)
            {
                var interactiveObject = _executableObjects[i];
                
                switch (interactiveObject)
                {
                    case HealthBonus healthBonus:
                        healthBonus.OnInteraction -= _displayHealth.HealOrDamage;
                        break;
                    case KeyBonus keyBonus:
                        keyBonus.OnInteraction -= _displayKey.ShowKey;
                        break;
                }
            }

            _exitDoor.OnEnter -= _displayWin.ShowWin;
        }

        #endregion
        
    }
}