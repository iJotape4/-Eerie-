using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Interactables 
{
    public class BibleInScene : WeaponInScene
    {
        MeshRenderer mesh;

        public new void Start()
        {
            base.Start();
            mesh = GetComponent<MeshRenderer>();
        }


        public override void Pick()
        {
            TurnShowItemOnScene(false);
            interactableEventsScriptableObject.PickBible(weaponType.GetStatsValues());
        }

        public override void Respawn()=>       
            TurnShowItemOnScene(true);
        

        public override void TurnShowItemOnScene(bool show)
        {
            bc.enabled = show;
            mesh.enabled =show;
            rb.detectCollisions = show;
            rb.isKinematic =!show;
        }
        
    }
}
