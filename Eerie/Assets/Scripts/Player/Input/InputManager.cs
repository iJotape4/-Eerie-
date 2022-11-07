using UnityEngine;

namespace PlayerScripts
{
    [RequireComponent(typeof(PlayerMovement))]
    [RequireComponent(typeof(PlayerLook))]
    [RequireComponent(typeof(PlayerStatsListener))]
    [RequireComponent(typeof(PlayerInteract))]
    [RequireComponent(typeof(WeaponsManager))]
    [RequireComponent(typeof(PlayerAttack))]
    public class InputManager : MonoBehaviour
    {
        [SerializeField] PlayerMovement movement;
        [SerializeField] PlayerLook mouseLook;
        [SerializeField] PlayerStatsListener stats;
        [SerializeField] PlayerInteract pickUp;
        [SerializeField] WeaponsManager weaponsManager;
        [SerializeField] PlayerAttack playerAttack;

        PlayerInput controls;
        PlayerInput.PlayerActions groundMovement;

        Vector2 horizontalInput;
        Vector2 mouseInput;
        Vector2 mousePosition;
        bool jump;
        bool interact;
        WeaponsList currentWeapon;
        bool fire1, holdFire1, fire2, holdFire2;
        

        private void Awake() 
        {
            movement=GetComponent<PlayerMovement>();
            mouseLook=GetComponent<PlayerLook>();
            stats=GetComponent<PlayerStatsListener>();

            pickUp = GetComponent<PlayerInteract>();
            weaponsManager = GetComponent<WeaponsManager>();
            playerAttack = GetComponent<PlayerAttack>();

            controls = new PlayerInput();
            groundMovement = controls.Player;
    
            groundMovement.Move.performed += ctx => horizontalInput = ctx.ReadValue<Vector2>();

            groundMovement.Look.performed += ctx => mouseInput = ctx.ReadValue<Vector2>();

            groundMovement.MousePosition.performed += ctx => mousePosition = ctx.ReadValue<Vector2>();
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
            fire1= groundMovement.Fire1.WasReleasedThisFrame();
            holdFire1 = groundMovement.Fire1.IsPressed();
            fire2= groundMovement.Fire2.WasReleasedThisFrame();
            holdFire2 = groundMovement.Fire2.IsPressed();
            
            movement.ReceiveInput(horizontalInput, jump);
            mouseLook.ReceiveInput(mouseInput);
            stats.ReceiveInput(jump);
            pickUp.ReceiveInput(interact, mousePosition);
            weaponsManager.ReceiveInput(currentWeapon);
            playerAttack.ReceiveInput(fire1, holdFire1, fire2, holdFire2);
        }

        private WeaponsList  SetCurrentWeapon()
        {
            WeaponsList selectedWeapon=currentWeapon;

            if(groundMovement.SelectWeapon1.WasReleasedThisFrame())
                selectedWeapon = WeaponsList.Barehand;
            if(groundMovement.SelectWeapon2.WasReleasedThisFrame())
                selectedWeapon = WeaponsList.Bible;
            if(groundMovement.SelectWeapon3.WasReleasedThisFrame())
                selectedWeapon = WeaponsList.HolyWater;

            return selectedWeapon;
        }

    }
}
