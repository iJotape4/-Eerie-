using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Interactables
{
    [RequireComponent(typeof(Rigidbody))]
    [RequireComponent(typeof(BoxCollider))]
    public abstract class WeaponInScene : PickableItem, IAutoRotatable, IRespawneable
    {
        [HideInInspector] protected Rigidbody rb;
        [HideInInspector] protected BoxCollider bc;

        [Range(0.001f, 0.01f)]
        public float rotationSpeed = 0.005f;

        public new void Start()
        {
            base.Start();
            rb = GetComponent<Rigidbody>();
            rb.useGravity = false;
            bc = GetComponent<BoxCollider>();
            CallRotation();
        }
        public IEnumerator RotateOnItsOwnAxis()
        {
            while(bc.enabled)
            {
                rb.AddTorque(Vector3.up*rotationSpeed);
                yield return null;
            }
        }

        public void CallRotation()
        {
            StartCoroutine(RotateOnItsOwnAxis());
        }

        public abstract override void Pick();
        
        public abstract void Respawn();
        public abstract void TurnShowItemOnScene(bool show);

    } 
}
