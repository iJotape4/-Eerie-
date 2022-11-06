using UnityEngine;
using System.Collections;

namespace Interactables
{
    public class ElevatorButtonUP : ElevatorButton
    {
        public override void Interact()
        {
            base.Interact();
            if(Elevator.GetBool(animationElevator) || Elevator.GetCurrentAnimatorStateInfo(0).IsName("AscensorBajando"))
            {
                StartCoroutine(ReactivateElevatorButton());
                return;
            }

            foreach(Animator anim in DoorsToClose)
            anim.SetBool(animationOpenDoor, false);

            StartCoroutine(ElevatorUP());
        }

        protected IEnumerator ElevatorUP()
        {
            yield return new WaitForSeconds(3f);
            Elevator.SetBool(animationElevator, true);
        }
       
    }

}
