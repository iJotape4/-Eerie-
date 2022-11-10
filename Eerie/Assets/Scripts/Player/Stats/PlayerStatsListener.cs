using UnityEngine;
using GameEvents;
using Enemies;

namespace PlayerScripts
{
    public class PlayerStatsListener : MonoBehaviour, IDamageable
    {
        public PlayerStatsScriptableObject playerStats;

        [Header("Consumable Stats")]
        [SerializeField] protected float _health;
        [SerializeField] protected float _maxHealth;
        [SerializeField] protected float _mana;
        [SerializeField] protected float _maxMana;

        [Header("Equipment Stats")]
        [SerializeField] protected float _speed;
        [SerializeField] protected float _damage;
        [SerializeField] protected float _armor;
        [SerializeField] protected float _magicalDamage;
        [SerializeField] protected float _equipmentWeight;   
        [SerializeField] protected float _maxEquipmentWeight; 
        

        private void OnEnable() 
        {
            playerStats.healthChangeEvent += ChangeHealth;
            playerStats.maxHealthChangeEvent+=ChangeMaxHealth;
            playerStats.manaChangeEvent+=ChangeMana;
            playerStats.maxManaChangeEvent+=ChangeMaxMana;
            playerStats.speedChangeEvent+=ChangeSpeed;  
            playerStats.damageChangeEvent+= ChangeDamage; 
            playerStats.armorChangeEvent+= ChangeArmor;
            playerStats.magicalDamageChangeEvent+=ChangeMagicalDamage;
            playerStats.equipmentWeightChangeEvent+=ChangeEquipmentWeight;
            playerStats.maxEquipmentWeightChangeEvent+=ChangeMaxEquipmentWeight;
        }

         private void OnDisable()                     
        {
            playerStats.healthChangeEvent -= ChangeHealth;
            playerStats.maxHealthChangeEvent-=ChangeMaxHealth;
            playerStats.manaChangeEvent-=ChangeMana;
            playerStats.maxManaChangeEvent-=ChangeMaxMana;
            playerStats.speedChangeEvent-=ChangeSpeed;  
            playerStats.damageChangeEvent-= ChangeDamage; 
            playerStats.armorChangeEvent-= ChangeArmor;
            playerStats.magicalDamageChangeEvent-=ChangeMagicalDamage;
            playerStats.equipmentWeightChangeEvent-=ChangeEquipmentWeight;
            playerStats.maxEquipmentWeightChangeEvent-=ChangeMaxEquipmentWeight;
        }

        public void ChangeHealth(float health)=>      
            _health = health;
                
        public void ChangeMaxHealth(float maxHealth)=>      
            _maxHealth = maxHealth;

        public void ChangeMana(float mana)=>      
            _mana = mana;
        
        public void ChangeMaxMana(float maxMana)=>      
            _maxMana = maxMana;

        private void ChangeSpeed(float speed)=>      
            _speed = speed;

        private void ChangeArmor(float armor)=>        
            _armor = armor;
        
        private void ChangeDamage(float damage)=>       
            _damage = damage;       

        private void ChangeMagicalDamage(float magicalDamage)=>      
            _magicalDamage = magicalDamage;
        
        private void ChangeEquipmentWeight(float equipmentWeight)=>      
            _equipmentWeight = equipmentWeight;

        private void ChangeMaxEquipmentWeight(float maxEquipmentWeight)=>      
            _maxEquipmentWeight = maxEquipmentWeight;

        public void ReceiveInput(bool jump)
        {
            if(jump)
                playerStats.DecreaseHealth(17);
        }

        private void OnCollisionEnter(Collision other) 
        {
            if(other.gameObject.tag == "Enemy")
            {
                playerStats.damageReceivedEvent?.Invoke();
                float damage = other.gameObject.GetComponent<Enemy>()._damage;
                playerStats.DecreaseHealth(damage);
            }
        }
    }
}
