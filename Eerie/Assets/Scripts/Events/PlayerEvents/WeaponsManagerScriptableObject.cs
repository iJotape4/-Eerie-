using UnityEngine;
using UnityEngine.Events;

namespace GameEvents
{
    [CreateAssetMenu(fileName = "Weapons Events Manager", menuName = "ScriptableObjects/Events/Weapons Manager", order = 1)]
    public class WeaponsManagerScriptableObject : ScriptableObject
    {
        [System.NonSerialized] public UnityAction playerAttack1Event; 
        [System.NonSerialized] public UnityAction playerHoldAttack1Event;
        [System.NonSerialized] public UnityAction playerAttack2Event;
        [System.NonSerialized] public UnityAction playerHoldAttack2Event;

        public void Fire1()=>
            playerAttack1Event?.Invoke();

        public void HoldFire1()=>
            playerHoldAttack1Event?.Invoke();

        public void Fire2()=>
            playerAttack2Event?.Invoke();      
        
        public void HoldFire2()=>
            playerHoldAttack2Event?.Invoke();
    }
}
