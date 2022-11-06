using UnityEngine;

namespace PlayerScripts
{
    [RequireComponent(typeof(PlayerMovement))]
    [RequireComponent(typeof(PlayerLook))]
    [RequireComponent(typeof(PlayerStatsListener))]
    [RequireComponent(typeof(PlayerInteract))]
    public class InputManager : MonoBehaviour
    {
    [SerializeField] PlayerMovement movement;
       [SerializeField] PlayerLook mouseLook;
       [SerializeField] PlayerStatsListener stats;
       [SerializeField] PlayerInteract pickUp;
        //[SerializeField] Fire fire;

        PlayerInput controls;
        PlayerInput.PlayerActions groundMovement;

        Vector2 horizontalInput;
        Vector2 mouseInput;
        Vector2 mousePosition;
        bool jump;
        bool interact;
        /*bool shoot;
        bool holdShoot;*/

        private void Awake() 
        {
            movement=GetComponent<PlayerMovement>();
            mouseLook=GetComponent<PlayerLook>();
            stats=GetComponent<PlayerStatsListener>();

            pickUp = GetComponent<PlayerInteract>();
            /*fire = GetComponent<Fire>();*/

            controls = new PlayerInput();
            groundMovement = controls.Player;
    
            groundMovement.Move.performed += ctx => horizontalInput = ctx.ReadValue<Vector2>();

            groundMovement.Look.performed += ctx => mouseInput = ctx.ReadValue<Vector2>();

            groundMovement.MousePosition.performed += ctx => mousePosition = ctx.ReadValue<Vector2>();
            
            //groundMovement.Look.performed += ctx => mouseInput.y = ctx.ReadValue<float>();
        }

        private void OnEnable() 
        {
        controls.Enable();
        }

        private void OnDestroy() 
        {
            controls.Disable();
        }

        void Update()
        {
            jump = groundMovement.Jump.WasReleasedThisFrame();
            interact = groundMovement.Interact.WasReleasedThisFrame();
            
            movement.ReceiveInput(horizontalInput, jump);
            mouseLook.ReceiveInput(mouseInput);
            stats.ReceiveInput(jump);
            pickUp.ReceiveInput(interact, mousePosition);

            /*shoot = groundMovement.Fire.WasReleasedThisFrame();
            holdShoot = groundMovement.Fire.IsPressed();

            
            fire.ReceiveInput(shoot, holdShoot);*/

        }

    }
}
