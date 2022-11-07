using UnityEngine;

namespace WeaponsScripts
{
    public abstract class  Weapon : MonoBehaviour, IPrimaryAttackweapon
    {
        protected string _animAttackTrigger = "Attack";
        public abstract void PrimaryAttack();
    }
}
