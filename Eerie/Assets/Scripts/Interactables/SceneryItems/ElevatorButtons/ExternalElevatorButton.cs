using UnityEngine;

namespace Interactables
{
    public class ExternalElevatorButton : InGameButton
    {
        [SerializeField] public Animator[] DoorsToOpen = null;
        [HideInInspector] public string animationOpenDoor = "AbrirPuertas";

        public override void Interact()
        {
            foreach(Animator anim in DoorsToOpen)          
                anim.SetBool(animationOpenDoor, true);
            
            base.Interact();
        }

 
    }

}
