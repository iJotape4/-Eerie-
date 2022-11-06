using UnityEngine;

namespace Interactables
{
    public abstract class InteractableItem : MonoBehaviour, IInteractable
    {
        protected const string ItemTag = "InteractableItem";
        public abstract void Interact();


        public void Start()=>
            this.gameObject.tag = ItemTag;
        
    }
}
