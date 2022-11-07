using UnityEngine;

namespace Interactables
{
    public class PantsInScene : WeaponInScene
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
                interactableEventsScriptableObject.PickPants(weaponType.GetStatsValues());
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
