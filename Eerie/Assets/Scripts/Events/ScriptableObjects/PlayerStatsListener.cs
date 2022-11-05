using UnityEngine;
using GameEvents;

namespace PlayerScripts
{
    public class PlayerStatsListener : MonoBehaviour
    {
        public PlayerEvents playerStats;

        [Header("Consumable Stats")]
        [SerializeField] protected float _health;
        [SerializeField] protected float _maxHealth;
        [SerializeField] protected float _mana;
        [SerializeField] protected float _maxMana;

        [Header("Equipment Stats")]
        [SerializeField] protected float _damage;
        [SerializeField] protected float _armor;
        [SerializeField] protected float _magicalDamage;

        private void OnEnable() 
        {
            playerStats.armorChangeEvent+= ChangeHealth;  
            playerStats.damageChangeEvent+= ChangeDamage; 
            playerStats.armorChangeEvent+= ChangeArmor;
        }

         private void OnDisable()                     
        {
            playerStats.healthChangeEvent-= ChangeHealth;  
            playerStats.damageChangeEvent-= ChangeDamage; 
            playerStats.armorChangeEvent-= ChangeArmor;
        }

        private void ChangeHealth(float health)
        {
            _health = health;
        }

        private void ChangeArmor(float armor)
        {
            _armor = armor;
        }

        private void ChangeDamage(float damage)
        {
            _damage = damage;
        }
    }
}
