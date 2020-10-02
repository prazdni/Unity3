using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Object = UnityEngine.Object;

namespace MyLabyrinth
{
    public sealed class UIController : IDisposable
    {
        #region Fields

        private readonly ListExecuteObjects _executeObjects;
        private IConnectUIRestart _connectedObject;

        #endregion

        #region ClassLifeCycles

        public UIController(ListExecuteObjects executeObjects)
        {
            _executeObjects = executeObjects;

            for (int i = 0; i < _executeObjects.Length; i++)
            {
                var interactiveObject = _executeObjects[i];
                
                if (interactiveObject is HealthBonus healthBonus)
                {
                    healthBonus.HealedOrDamagedPlayer += HealthEffect;
                }

                if (interactiveObject is KeyBonus keyBonus)
                {
                    keyBonus.ShowKey += ShowKey;
                }
            }

            _connectedObject = Object.FindObjectOfType<ExitDoor>();
            _connectedObject.OnAction += ShowWin;
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
            for (int i = 0; i < _executeObjects.Length; i++)
            {
                var interactiveObject = _executeObjects[i];
                
                if (interactiveObject is HealthBonus healthBonus)
                {
                    healthBonus.HealedOrDamagedPlayer -= HealthEffect;
                }

                if (interactiveObject is KeyBonus keyBonus)
                {
                    keyBonus.ShowKey -= ShowKey;
                }
            }
        }

        #endregion
        
    }
}