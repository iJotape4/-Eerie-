using UnityEngine;
using UnityEngine.Events;

namespace GameEvents
{
    [CreateAssetMenu(fileName = "Player Stats", menuName = "ScriptableObjects/Events/Player Stats", order = 1)]
    public class PlayerStatsScriptableObject : ScriptableObject
    {
        [Header("Consumable Stats")]
        [SerializeField] protected float health;
        [SerializeField] protected float maxHealth=100f;
        [SerializeField] protected float mana;
        [SerializeField] protected float maxMana=100f;

        [Header("Equipment Stats")]
        [SerializeField] protected float speed=1f;
        [SerializeField] protected float damage=1f;
        [SerializeField] protected float armor=0f;
        [SerializeField] protected float magicalDamage=1f;   
        [SerializeField] protected float equipmentWeight=0f;   
        [SerializeField] protected float maxEquipmentWeight=100f;  

        [System.NonSerialized] public UnityAction<float> healthChangeEvent; 
        [System.NonSerialized] public UnityAction<float> maxHealthChangeEvent;
        [System.NonSerialized] public UnityAction<float> damageChangeEvent;
        [System.NonSerialized] public UnityAction<float> armorChangeEvent;
        [System.NonSerialized] public UnityAction<float> magicalDamageChangeEvent;
        [System.NonSerialized] public UnityAction<float> manaChangeEvent;
        [System.NonSerialized] public UnityAction<float> maxManaChangeEvent;
        [System.NonSerialized] public UnityAction<float> speedChangeEvent;
        [System.NonSerialized] public UnityAction<float> equipmentWeightChangeEvent;
        [System.NonSerialized] public UnityAction<float> maxEquipmentWeightChangeEvent;

        [System.NonSerialized] public UnityAction deathEvent;
        [System.NonSerialized] public UnityAction<bool> interactableFoundEvent;
        [System.NonSerialized] public UnityAction itemPickedEvent;
        [System.NonSerialized] public UnityAction damageReceivedEvent;

        private void OnEnable()
        {
            health = maxHealth;
            mana=maxMana;
            speed=1f;
            damage=1f;
            armor=0f;
            magicalDamage=1f;               
            equipmentWeight = 0f;
        }

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

        public void IncreaseMaxHealth(float amount)
        {
            maxHealth+=amount;
            maxHealthChangeEvent?.Invoke(maxHealth);
        }

        public void DecreaseMaxHealth(float amount) 
        {           
            maxHealth -= amount;
            maxHealthChangeEvent?.Invoke(maxHealth);
        } 

        public void IncreaseMana(float amount)
        {
            mana += amount;
            manaChangeEvent?.Invoke(mana);
        }
        
        public void DecraseMana(float amount) 
        {           
            mana -= amount;
            manaChangeEvent?.Invoke(mana);
        }  

         public void IncreaseMaxMana(float amount)
        {
            maxMana += amount;
            maxManaChangeEvent?.Invoke(maxMana);
        }
        
        public void DecreaseMaxMana(float amount) 
        {           
            maxMana -= amount;
            maxManaChangeEvent?.Invoke(maxMana);
        } 

         public void IncreaseSpeed(float amount)
        {
            speed += amount;
            speedChangeEvent?.Invoke(speed);
        }
        
        public void DecreaseSpeed(float amount) 
        {           
            speed -= amount;
            speedChangeEvent?.Invoke(speed);
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

        public void IncreaseMagicalDamage(float amount)
        {
            magicalDamage+=amount;
            magicalDamageChangeEvent?.Invoke(magicalDamage);
        }

        public void DecreaseMagicalDamage(float amount) 
        {           
            magicalDamage -= amount;
            magicalDamageChangeEvent?.Invoke(magicalDamage);
        } 

         public void IncreaseEquipmentWeight(float amount)
        {
            equipmentWeight+=amount;
            equipmentWeightChangeEvent?.Invoke(equipmentWeight);
        }

        public void DecreaseEquipmentWeight(float amount) 
        {           
            equipmentWeight -= amount;
            equipmentWeightChangeEvent?.Invoke(equipmentWeight);
        } 

         public void IncreaseMaxEquipmentWeight(float amount)
        {
            maxEquipmentWeight+=amount;
            maxEquipmentWeightChangeEvent?.Invoke(maxEquipmentWeight);
        }

        public void DecreaseMaxEquipmentWeight(float amount) 
        {            
            maxEquipmentWeight -= amount;
            maxEquipmentWeightChangeEvent?.Invoke(maxEquipmentWeight);
        }

        public float GetCurrentMana()
        {
            return mana; 
        }

        public void WeaponPicked(float[] stats)
        {
            IncreaseHealth(stats[0]);
            IncreaseMaxHealth(stats[1]);
            IncreaseMana(stats[2]);
            IncreaseMaxMana(stats[3]);
            IncreaseSpeed(stats[4]);
            IncreaseDamage(stats[5]);
            IncreaseArmor(stats[6]);
            IncreaseMagicalDamage(stats[7]);
            IncreaseEquipmentWeight(stats[8]);
            IncreaseMaxEquipmentWeight(stats[9]);
        }    
    }
}

