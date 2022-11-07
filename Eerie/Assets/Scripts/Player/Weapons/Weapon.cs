using UnityEngine;
using GameEvents;

namespace WeaponsScripts
{
    public abstract class  Weapon : MonoBehaviour, IPrimaryAttackweapon
    {
        [SerializeField] public WeaponsManagerScriptableObject weaponsManagerScriptableObject;
        protected string _animAttackTrigger = "Attack";
        protected abstract void AssignAttackEventsListeners();
        public abstract void PrimaryAttack();

        public void Start()=>      
            AssignAttackEventsListeners();
        
    }
}
