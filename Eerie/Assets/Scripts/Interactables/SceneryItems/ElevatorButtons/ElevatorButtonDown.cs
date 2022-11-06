using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Interactables
{
    public class ElevatorButtonDown : ElevatorButton
    {
        public override void Interact()
        {
            base.Interact();
            if(!Elevator.GetBool(animationElevator) || Elevator.GetCurrentAnimatorStateInfo(0).IsName("AscensorSubiendo"))
            {
                StartCoroutine(ReactivateElevatorButton());
                return;
            }

            foreach(Animator anim in DoorsToClose)
            anim.SetBool(animationOpenDoor, false);

            StartCoroutine(ElevatorDown());
        }

        protected IEnumerator ElevatorDown()
        {
            yield return new WaitForSeconds(3f);
            Elevator.SetBool(animationElevator, false);
        }
    }

}
