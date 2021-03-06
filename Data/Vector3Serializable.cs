﻿using System;
using UnityEngine;

namespace MyLabyrinth
{
    [Serializable]
    public struct Vector3Serializable
    {
        #region Fields

        public float X;
        public float Y;
        public float Z;

        #endregion


        #region ClassLifeCycles

        public Vector3Serializable(float x, float y, float z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        #endregion


        #region Methods

        public override string ToString()
        {
            return $"(X = {X}, Y = {Y}, Z = {Z})";
        }

        #endregion


        #region Operators

        public static implicit operator Vector3(Vector3Serializable value)
        {
            return new Vector3(value.X, value.Y, value.Z);
        }
        
        public static implicit operator Vector3Serializable(Vector3 value)
        {
            return new Vector3Serializable(value.x, value.y, value.z);
        }

        #endregion
    }
}

