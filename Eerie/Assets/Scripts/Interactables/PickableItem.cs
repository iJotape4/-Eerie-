
using UnityEngine;

namespace Interactables
{
    public abstract class PickableItem : InteractableItem, IPickable
    {
        protected new string ItemTag = "PickableItem";
        public override void Interact()
        {
            Pick();
        }

        public abstract void Pick();
        
        public  new void Start() =>
            this.gameObject.tag = ItemTag;
    }
}
