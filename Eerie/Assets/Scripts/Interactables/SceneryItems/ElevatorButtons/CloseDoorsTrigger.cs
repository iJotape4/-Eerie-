using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Interactables
{
    public class CloseDoorsTrigger : MonoBehaviour
    {
        [SerializeField] ExternalElevatorButton externalElevatorButton;

        private void Start() 
        {
            externalElevatorButton = GetComponentInParent<ExternalElevatorButton>();
        }

        private void OnTriggerEnter(Collider other) 
        {
          if(other.gameObject.tag == "Player")
          {
            Debug.Log("on");
            foreach(Animator anim in externalElevatorButton.DoorsToOpen)          
                anim.SetBool(externalElevatorButton.animationOpenDoor, false);
            
                externalElevatorButton.ReactivateInteraction();
          }   
        }
    }
}
