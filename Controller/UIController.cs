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

        private readonly ListExecuteObjectsAndControllers _executeObjectsAndControllers;

        #endregion

        #region ClassLifeCycles

        public UIController(ListExecuteObjectsAndControllers executeObjectsAndControllers)
        {
            _executeObjectsAndControllers = executeObjectsAndControllers;

            for (int i = 0; i < _executeObjectsAndControllers.Length; i++)
            {
                var interactiveObject = _executeObjectsAndControllers[i];
                
                switch (interactiveObject)
                {
                    case HealthBonus healthBonus:
                        healthBonus.HealedOrDamagedPlayer += HealthEffect;
                        break;
                    case KeyBonus keyBonus:
                        keyBonus.ShowKey += ShowKey;
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
            for (int i = 0; i < _executeObjectsAndControllers.Length; i++)
            {
                var interactiveObject = _executeObjectsAndControllers[i];
                
                switch (interactiveObject)
                {
                    case HealthBonus healthBonus:
                        healthBonus.HealedOrDamagedPlayer -= HealthEffect;
                        break;
                    case KeyBonus keyBonus:
                        keyBonus.ShowKey -= ShowKey;
                        break;
                    default:
                        break;
                }
            }
        }

        #endregion
        
    }
}