using UnityEngine;
namespace WeaponsScripts
{
    public class WeaponScriptableObject : ScriptableObject
    {
        [SerializeField] WeaponType weaponType;

        [SerializeField] new string name;
        [Header("Item Stats")]
        [SerializeField] protected float _health;
        [SerializeField] protected float _maxHealth;
        [SerializeField] protected float _mana;
        [SerializeField] protected float _maxMana;
        [SerializeField] protected float _speed;
        [SerializeField] protected float _damage;
        [SerializeField] protected float _armor;
        [SerializeField] protected float _magicalDamage;
        [SerializeField] protected float weight;
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
