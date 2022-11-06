using UnityEngine;
using Interactables;

namespace PlayerScripts
{
    [RequireComponent(typeof(PlayerStatsListener))]
    public class PlayerInteract : MonoBehaviour
    {
        bool _interact;
        Vector2 _mousePosition;

    //[SerializeField] private GameObject pickedItem;
        //public PlayerWeaponsManagerScriptableObject weaponsManager;
        [SerializeField] private string interactableItemTag = "InteractableItem";
        [SerializeField] private string pickabletemTag = "PickableItem";
        [SerializeField] private PlayerStatsListener playerStatsListener;

    /* 
        [SerializeField] private Material higLightMaterial;
        [SerializeField] private Material defaultMaterial;*/

        private Transform _selection;
        [SerializeField] private Camera _cam;
        
        private void Start() 
        {
            playerStatsListener = GetComponent<PlayerStatsListener>();
        }

        private void Update()
        {
            DetectItems();
        }

        public void DetectItems()
        {
            if(_selection!= null)
            {
                playerStatsListener.playerStats.interactableFoundEvent?.Invoke(false);
                _selection =null;
            }

            var ray = _cam.ScreenPointToRay(_mousePosition);
            RaycastHit hit;

            if(Physics.Raycast(ray, out hit))
            {
                var selection = hit.transform;

                if(selection.CompareTag(interactableItemTag))
                {
                    _selection = selection;
                    playerStatsListener.playerStats.interactableFoundEvent?.Invoke(true);

                    if(_interact)
                    {
                        _selection.gameObject.GetComponent<InteractableItem>().Interact();
                /*       if(pickedItem!=null)
                        {
                            pickedItem.Interact(false);
                        }

                    pickedItem = _selection.GetComponent<Interactable>();
                    pickedItem.Interact(true);
                    weaponsManager.ChangePlayerWeapon(pickedItem.name);*/
                    }
                }
                else
                {
                    
                }
            }
        }

        public void ReceiveInput(bool interact, Vector2 mousePosition){
            _interact = interact;
            _mousePosition = mousePosition;
        }
    }
}
