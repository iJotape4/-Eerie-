using UnityEngine;

namespace Interactables
{
    public abstract class InteractableItem : MonoBehaviour, IInteractable
    {
        protected string ItemTag = "InteractableItem";
        public abstract void Interact();


        public void Start()=>
            this.gameObject.tag = ItemTag;
        
    }
}
