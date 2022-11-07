using UnityEngine;

namespace Interactables
{
    public class ShirtInScene : WeaponInScene
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
            interactableEventsScriptableObject.PickShirt(weaponType.GetStatsValues());
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
