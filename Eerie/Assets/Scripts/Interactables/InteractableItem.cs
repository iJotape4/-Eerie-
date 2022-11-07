using UnityEngine;
using GameEvents;

namespace Interactables
{
    public abstract class InteractableItem : MonoBehaviour, IInteractable
    {
        [SerializeField] protected InteractableEventsScriptableObject interactableEventsScriptableObject;
        protected const string ItemTag = "InteractableItem";
        public abstract void Interact();


        public void Start()=>
            this.gameObject.tag = ItemTag;
        
    }
}
