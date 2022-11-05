using UnityEngine;
using UnityEngine.Events;

namespace GameEvents
{
    [CreateAssetMenu(fileName = "Player Stats", menuName = "ScriptableObjects/Player Stats", order = 1)]
    public class PlayerStatsScriptableObject : ScriptableObject
    {
        [Header("Consumable Stats")]
        [SerializeField] protected float health;
        [SerializeField] protected float maxHealth=100f;
        [SerializeField] protected float mana;
        [SerializeField] protected float maxMana=100f;

        [Header("Equipment Stats")]
        [SerializeField] protected float damage=1f;
        [SerializeField] protected float armor;
        [SerializeField] protected float magicalDamage=1f;       

        [System.NonSerialized] public UnityAction<float> healthChangeEvent; 
        [System.NonSerialized] public UnityAction<float> damageChangeEvent;
        [System.NonSerialized] public UnityAction<float> armorChangeEvent;

        [System.NonSerialized] public UnityAction deathEvent;

        private void OnEnable()=>
            health = maxHealth;               

        public void IncreaseHealth(float amount)
        {
            if(health+amount > maxHealth)
                return;

            health += amount;
            healthChangeEvent?.Invoke(health);
        }
        
        public void DecreaseHealth(float amount) 
        {   
            health -= amount;
            if(health < 0)
            {
                health = 0;
                deathEvent?.Invoke();
            }
            healthChangeEvent?.Invoke(health);
        }

        public void IncreaseArmor(float amount)
        {
            armor += amount;
            armorChangeEvent?.Invoke(armor);
        }
        
        public void DecreaseArmor(float amount) 
        {           
            armor -= amount;
            armorChangeEvent?.Invoke(armor);
        }  

         public void IncreaseDamage(float amount)
        {
            damage += amount;
            damageChangeEvent?.Invoke(damage);
        }
        
        public void DecreaseDamage(float amount) 
        {           
            damage -= amount;
            damageChangeEvent?.Invoke(damage);
        }    
    }
}

