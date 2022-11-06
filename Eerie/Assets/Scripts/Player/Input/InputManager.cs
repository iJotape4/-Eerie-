using UnityEngine;

namespace PlayerScripts
{
    [RequireComponent(typeof(PlayerMovement))]
    [RequireComponent(typeof(PlayerLook))]
    [RequireComponent(typeof(PlayerStatsListener))]
    [RequireComponent(typeof(PlayerInteract))]
    [RequireComponent(typeof(WeaponsManager))]
    public class InputManager : MonoBehaviour
    {
    [SerializeField] PlayerMovement movement;
       [SerializeField] PlayerLook mouseLook;
       [SerializeField] PlayerStatsListener stats;
       [SerializeField] PlayerInteract pickUp;
        [SerializeField] WeaponsManager weaponsManager;
        //[SerializeField] Fire fire;

        PlayerInput controls;
        PlayerInput.PlayerActions groundMovement;

        Vector2 horizontalInput;
        Vector2 mouseInput;
        Vector2 mousePosition;
        bool jump;
        bool interact;
        int currentWeapon;
        /*bool shoot;
        bool holdShoot;*/

        private void Awake() 
        {
            movement=GetComponent<PlayerMovement>();
            mouseLook=GetComponent<PlayerLook>();
            stats=GetComponent<PlayerStatsListener>();

            pickUp = GetComponent<PlayerInteract>();
            weaponsManager = GetComponent<WeaponsManager>();
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
            currentWeapon = SetCurrentWeapon();
            
            movement.ReceiveInput(horizontalInput, jump);
            mouseLook.ReceiveInput(mouseInput);
            stats.ReceiveInput(jump);
            pickUp.ReceiveInput(interact, mousePosition);
            weaponsManager.ReceiveInput(currentWeapon);


            /*shoot = groundMovement.Fire.WasReleasedThisFrame();
            holdShoot = groundMovement.Fire.IsPressed();

            
            fire.ReceiveInput(shoot, holdShoot);*/

        }

        private int  SetCurrentWeapon()
        {
            int selectedWeapon=currentWeapon;

            if(groundMovement.SelectWeapon1.WasReleasedThisFrame())
                selectedWeapon = 0;
            if(groundMovement.SelectWeapon2.WasReleasedThisFrame())
                selectedWeapon = 1;
            if(groundMovement.SelectWeapon3.WasReleasedThisFrame())
                selectedWeapon = 2;

            return selectedWeapon;
        }

    }
}
