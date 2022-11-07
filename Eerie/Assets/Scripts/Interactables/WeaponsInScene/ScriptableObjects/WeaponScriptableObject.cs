using UnityEngine;
namespace WeaponsScripts
{
    public class WeaponScriptableObject : ScriptableObject
    {
        [SerializeField] WeaponType weaponType;

        [SerializeField] new string name;
        [Header("Item Stats")]
        [SerializeField] protected float _health=0f;
        [SerializeField] protected float _maxHealth=0f;
        [SerializeField] protected float _mana=0f;
        [SerializeField] protected float _maxMana=0f;
        [SerializeField] protected float _speed=0f;
        [SerializeField] protected float _damage=0f;
        [SerializeField] protected float _armor=0f;
        [SerializeField] protected float _magicalDamage=0f;
        [SerializeField] protected float _weight=0f;
        [SerializeField] protected float _maxEquipmentWeight=0f;

        public float[] GetStatsValues()
        {
            float[] stats=  {_health, _maxHealth, _mana, _maxMana, _speed, _damage, _armor, _magicalDamage, _weight, _maxEquipmentWeight};
            return  stats; 
        }
    }

    public enum WeaponType
    {
        Melee, 
        ProjectileSpawner, 
        Mixed, 
        Shield,
        Shoes,
        HeadCostume,
        ChestCostume,
        LegsCostume,
        Ring, 
        Necklace,
        Consumable,
        Pet
    }
}
