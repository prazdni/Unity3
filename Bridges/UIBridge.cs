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

        #endregion

        
        #region ClassLifeCycles

        public UIBridge(AllExecutableObjects listExecutableObjects)
        {
            _executableObjects = listExecutableObjects;
            //_executeBonuses = executeBonuses;

            for (int i = 0; i < _executableObjects.ExecutableObjectsCount; i++)
            {
                var interactiveObject = _executableObjects[i];

                switch (interactiveObject)
                {
                    case HealthBonus healthBonus:
                        healthBonus.OnInteraction += HealthEffect;
                        break;
                    case KeyBonus keyBonus:
                        keyBonus.OnInteraction += ShowKey;
                        break;
                }
            }

            var connectedObject = Object.FindObjectOfType<ExitDoor>();
            connectedObject.OnEnter += ShowWin;
        }

        #endregion


        #region Methods

        public void HealthEffect(object o, PlayerEventArgs args)
        {
            var displayHealth = Object.FindObjectOfType<DisplayHealth>();
            displayHealth.HealOrDamage(o, args);
        }

        public void ShowKey(object o, PlayerEventArgs args)
        {
            var displayKey = Object.FindObjectOfType<DisplayKey>();
            displayKey.ShowKey(o, args);
        }

        public void ShowWin(object o, PlayerEventArgs args)
        {
            var displayWin = Object.FindObjectOfType<DisplayWin>();
            displayWin.ShowWin(o, args);
        }
        
        #endregion


        #region IDisposable

        public void Dispose()
        {
            for (int i = 0; i < _executableObjects.ExecutableObjectsCount; i++)
            {
                var interactiveObject = _executableObjects[i];
                
                switch (interactiveObject)
                {
                    case HealthBonus healthBonus:
                        healthBonus.OnInteraction -= HealthEffect;
                        break;
                    case KeyBonus keyBonus:
                        keyBonus.OnInteraction -= ShowKey;
                        break;
                }
            }
        }

        #endregion
        
    }
}