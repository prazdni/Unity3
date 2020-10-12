using System;
using System.Collections;
using System.Collections.Generic;

namespace MyLabyrinth
{
    [Serializable]
    public sealed class SavedData
    {
        public string Name;
        public Vector3Serializable Position;
        public Vector3Serializable Rotation;
        public bool IsEnabled;

        public override string ToString()
        {
            return $"Name = {Name}, Position = {Position}, Rotation = {Rotation}, IsVisible = {IsEnabled}";
        }
    }
}

