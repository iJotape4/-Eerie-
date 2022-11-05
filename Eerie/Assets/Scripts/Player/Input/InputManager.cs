using UnityEngine;

namespace PlayerScripts
{
    [RequireComponent(typeof(PlayerMovement))]
    [RequireComponent(typeof(PlayerLook))]
    [RequireComponent(typeof(PlayerStatsListener))]
    public class InputManager : MonoBehaviour
    {
        [SerializeField] PlayerMovement movement;
       [SerializeField] PlayerLook mouseLook;
       [SerializeField] PlayerStatsListener stats;
       // [SerializeField] PickUp pickUp;
        //[SerializeField] Fire fire;

        PlayerInput controls;
        PlayerInput.PlayerActions groundMovement;

        Vector2 horizontalInput;
        Vector2 mouseInput;
        bool jump;
        /*bool interact;
        bool shoot;
        bool holdShoot;*/

        private void Awake() 
        {
            movement=GetComponent<PlayerMovement>();
            mouseLook=GetComponent<PlayerLook>();
             stats=GetComponent<PlayerStatsListener>();

            /*pickUp = GetComponent<PickUp>();
            fire = GetComponent<Fire>();*/

            controls = new PlayerInput();
            groundMovement = controls.Player;
    
            groundMovement.Move.performed += ctx => horizontalInput = ctx.ReadValue<Vector2>();

            groundMovement.Look.performed += ctx => mouseInput = ctx.ReadValue<Vector2>();
            
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
            jump = groundMovement.Jump.WasPerformedThisFrame();
            
            movement.ReceiveInput(horizontalInput, jump);
            mouseLook.ReceiveInput(mouseInput);
            stats.ReceiveInput(jump);

           /* interact = groundMovement.Interact.WasReleasedThisFrame();
            shoot = groundMovement.Fire.WasReleasedThisFrame();
            holdShoot = groundMovement.Fire.IsPressed();

            pickUp.ReceiveInput(interact);
            fire.ReceiveInput(shoot, holdShoot);*/

        }

    }
}
