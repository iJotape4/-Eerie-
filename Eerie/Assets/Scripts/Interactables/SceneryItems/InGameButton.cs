using UnityEngine;

namespace Interactables
{
    [RequireComponent(typeof(Animator))]
    public class InGameButton : InteractableItem, IReactivableInteraction
    {   
        [SerializeField] private MeshRenderer lightRing;
        [SerializeField] private GameObject elevator = null;
        [SerializeField] private Animator buttonAnimator = null;
        [SerializeField] private Animator elevator2 = null;
        [SerializeField] private Animator externaldoors1 = null;
        [SerializeField] private Animator externaldoors2 = null;
        [SerializeField] private Animator externaldoors3 = null;
        [SerializeField] private Animator internaldoors1 = null;
        [SerializeField] private Animator internaldoors2 = null;
        [SerializeField] private Object[] lightRings;

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
}
