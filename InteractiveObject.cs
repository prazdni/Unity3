using UnityEngine;

namespace MyLabyrinth
{
    public abstract class InteractiveObject : MonoBehaviour, IInteractable
    {
        public abstract bool IsInteractable();
    }
}