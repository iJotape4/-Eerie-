using UnityEngine;
using System.Collections;
using GameEvents;
using PlayerScripts;

namespace WeaponsScripts
{
    public class Bible : Weapon, ISecondaryAttackWeapon
    {
        [SerializeField] private WeaponsManagerScriptableObject weaponsManagerScriptableObject;
        [SerializeField] private WeaponsManager playerweaponsManager;

        protected override void AssignAttackEventsListeners() 
        {
            weaponsManagerScriptableObject.playerAttack1Event += PrimaryAttack;
            weaponsManagerScriptableObject.playerAttack2Event += SecondaryAttack;
        }
        //Bible Hit Attack
        public override void PrimaryAttack()
        {
            if(playerweaponsManager._currentWeaponIndex != WeaponsList.Bible)
                return;
                
            StartCoroutine(BibleHit());
        }

        //Biblioomerang Attack
        public void SecondaryAttack()
        {

        }

        public IEnumerator BibleHit()
        {            
            playerweaponsManager.CallAttackAnimationTrigger(_animAttackTrigger);
			playerweaponsManager.currentWeapon.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;						
			yield return null;
        }
    }
}
