using UnityEngine;
namespace Interactables
{
    public class BootsInScene : WeaponInScene
    {
        [SerializeField] private MeshRenderer[] meshes;

        public new void Start()
        {
            base.Start();
            meshes = GetComponentsInChildren<MeshRenderer>();
        }
        
        public override void Pick()
        {
            TurnShowItemOnScene(false);
            interactableEventsScriptableObject.PickBoots(weaponType.GetStatsValues());
        }

         public override void Respawn()=>
         TurnShowItemOnScene(true);


        public override void TurnShowItemOnScene(bool show)
        {
            bc.enabled = show;
            foreach(MeshRenderer mesh in meshes)
                mesh.enabled=show;
        }
    }
}
