using UnityEngine;

namespace WeaponsScripts
{
    public abstract class  Weapon : MonoBehaviour, IPrimaryAttackweapon
    {
        protected string _animAttackTrigger = "Attack";
        protected abstract void AssignAttackEventsListeners();
        public abstract void PrimaryAttack();

        public void Start()=>      
            AssignAttackEventsListeners();
        
    }
}
