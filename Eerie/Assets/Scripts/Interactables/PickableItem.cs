
using UnityEngine;

namespace Interactables
{
    public class PickableItem : InteractableItem, IPickable
    {
        new string ItemTag = "PickableItem";
        public override void Interact()
        {
            Pick();
        }

        public void Pick()
        {

        }
    }
}
