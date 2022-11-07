using UnityEngine;
using System.Collections;
using GameEvents;
using PlayerScripts;

namespace WeaponsScripts
{
    public class Barehand : Weapon
    {
        [SerializeField] ParticleSystem healVFX;
        [SerializeField] private PlayerStatsScriptableObject playerStatsScriptableObject;
        [SerializeField] private WeaponsManager playerweaponsManager;

        [SerializeField, Range(5f, 10f)] public float healthAmount;
        [SerializeField, Range(5f, 10f)] public float sourceManaCompsuption;
        [SerializeField] float HealVFXIterations =1f;

        protected override void AssignAttackEventsListeners() 
        {
            weaponsManagerScriptableObject.playerAttack1Event += PrimaryAttack;
            weaponsManagerScriptableObject.playerAttack2Event += PrimaryAttack;
        }
        //Heal 
        public override void PrimaryAttack()
        {
            if(playerweaponsManager._currentWeaponIndex != WeaponsList.Barehand)
                return;
                
            if(sourceManaCompsuption > playerStatsScriptableObject.GetCurrentMana())
                return;

            StartCoroutine(Heal());
        }

        public IEnumerator Heal()
        {            
            healVFX.Play();		
            playerStatsScriptableObject.IncreaseHealth(healthAmount);
            playerStatsScriptableObject.DecraseMana(sourceManaCompsuption);
			yield return new WaitForSeconds(HealVFXIterations*0.5f);
            healVFX.Stop();
        }
    }

}
