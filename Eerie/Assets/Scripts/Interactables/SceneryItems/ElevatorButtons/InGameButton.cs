using UnityEngine;
using System.Collections;

namespace Interactables
{
    [RequireComponent(typeof(Animator))]
    public class InGameButton : InteractableItem, IReactivableInteraction
    {   
        [SerializeField] private MeshRenderer lightRing;
        [SerializeField] private Animator buttonAnimator = null;

        protected string pressed = "Pressed";
        protected bool canInteract = true;

        private new void Start() 
        {
            base.Start();
            buttonAnimator = GetComponent<Animator>();
            lightRing = transform.GetChild(0).GetComponent<MeshRenderer>();
        }   

        public override void Interact()
        {
            if(!canInteract)
                return;

            buttonAnimator.SetBool(pressed,true);
            Material highlightedButton = new Material(Shader.Find("Universal Render Pipeline/Unlit"));
            lightRing.material = highlightedButton;  
            DeactivateInteraction();  ;
        }

        public void DeactivateInteraction()
        {
            canInteract = false;
        }   

        public void ReactivateInteraction()
        {
            Material offButton = new Material(Shader.Find("Universal Render Pipeline/Lit"));
            lightRing.material = offButton;
            buttonAnimator.SetBool(pressed,false);
            canInteract = true;
        }
    }

    public class ElevatorButton : InGameButton
    {
        [SerializeField] protected Animator Elevator =null;
        [SerializeField] protected Animator[] DoorsToClose = null;
        protected string animationOpenDoor = "AbrirPuertas";
        protected string animationElevator = "subir";

        public override void Interact()
        {
            base.Interact();
        }
        public new void ReactivateInteraction()
        {
            base.ReactivateInteraction();
        }

        public IEnumerator ReactivateElevatorButton()
        {
            yield return new WaitForSeconds(1f);
            base.ReactivateInteraction();
        }
    }
}
