using UnityEngine;
using System.Collections;
using GameEvents;
using PlayerScripts;

namespace  WeaponsScripts
{
    public class HolyWater : Weapon
    {
            [SerializeField] private WeaponsManager playerweaponsManager;

            protected override void AssignAttackEventsListeners() 
            {
                weaponsManagerScriptableObject.playerAttack1Event += PrimaryAttack;
                weaponsManagerScriptableObject.playerAttack2Event += PrimaryAttack;
            }

            //Holy  Water Attack
            public override void PrimaryAttack()
            {
                if(playerweaponsManager._currentWeaponIndex != WeaponsList.HolyWater)
                    return;

                StartCoroutine(ThrowAHolyWaterJet());
            }         

            public IEnumerator ThrowAHolyWaterJet()
            {            
                playerweaponsManager.CallAttackAnimationTrigger(_animAttackTrigger);               				
                yield return null;
            }
    } 
}
