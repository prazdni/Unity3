using UnityEngine;

namespace MyLabyrinth
{
    public interface IInteractable
    {
        Transform ObjectTransform { get; }
        
        bool IsInteractable();

        void SetInteractable(bool interactable);
    }
}
