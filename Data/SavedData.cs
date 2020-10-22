using System;
using System.Collections;
using System.Collections.Generic;

namespace MyLabyrinth
{
    [Serializable]
    public sealed class SavedData
    {
        #region Fields

        public string Name;
        public Vector3Serializable Position;
        public QuaternionSerializable Rotation;
        public bool IsEnabled;

        #endregion


        #region Methods

        public override string ToString()
        {
            return $"Name = {Name}, Position = {Position}, Rotation = {Rotation}, IsEnabled = {IsEnabled}";
        }

        #endregion
    }
}

