using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Interactables
{
    public class ElevatorOpenDoorsScript : MonoBehaviour
    {
        [SerializeField] private Animator[] DoorsToOpen = null;
        [SerializeField] private Animator DoorFirstFloor = null;
        [SerializeField] private InGameButton[] buttonsList = null;
        [HideInInspector] protected string animationOpenDoor = "AbrirPuertas"; 

        public void AnimationEventOpenElevatorDoorsUP()
        {
            foreach(Animator anim in DoorsToOpen)          
                    anim.SetBool(animationOpenDoor, true);

            foreach(InGameButton but in buttonsList)
                    but.ReactivateInteraction();
        }

        public void AnimationEventOpenElevatorDoorDown()
        {
            AnimationEventOpenElevatorDoorsUP();
            DoorFirstFloor.SetBool(animationOpenDoor, true);
        }
    }

}
