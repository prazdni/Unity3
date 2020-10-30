using System;
using UnityEngine;

namespace MyLabyrinth
{
    [Serializable]
    public struct QuaternionSerializable
    {
        #region Fields

        public float X;
        public float Y;
        public float Z;
        public float W;

        #endregion

        
        #region ClassLifeCycles

        public QuaternionSerializable(float x, float y, float z, float w)
        {
            X = x;
            Y = y;
            Z = z;
            W = w;
        }

        #endregion


        #region Methods

        public override string ToString()
        {
            return $"(X = {X}, Y = {Y}, Z = {Z}, W = {W})";
        }

        #endregion


        #region Operators

        public static implicit operator Quaternion(QuaternionSerializable value)
        {
            return new Quaternion(value.X, value.Y, value.Z, value.W);
        }
        
        public static implicit operator QuaternionSerializable(Quaternion value)
        {
            return new QuaternionSerializable(value.x, value.y, value.z, value.z);
        }

        #endregion
    }
}