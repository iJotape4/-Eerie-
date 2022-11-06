using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Interactables
{
    public class HolyWaterInScene : WeaponInScene
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
            interactableEventsScriptableObject.PickHolyWater(weaponType.GetStatsValues());
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
