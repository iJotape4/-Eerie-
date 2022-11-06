using UnityEngine;

namespace Interactables
{
    public class ExternalButton : InGameButton
    {
        [SerializeField] private Animator[] DoorsToOpen = null;
        protected string animationOpenDoor = "AbrirPuertas";

        public override void Interact()
        {
            foreach(Animator anim in DoorsToOpen)          
                anim.SetBool(animationOpenDoor, true);
            
            base.Interact();
        }
    }

}
