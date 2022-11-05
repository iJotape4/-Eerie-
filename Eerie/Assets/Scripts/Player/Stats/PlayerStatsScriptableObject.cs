using UnityEngine;

namespace PlayerScripts
{
    [CreateAssetMenu(fileName = "Player Stats", menuName = "ScriptableObjects/Player Stats", order = 1)]
    public class PlayerStatsScriptableObject : ScriptableObject
    {
        [Header("Consumable Stats")]
        [SerializeField] protected float health;
        [SerializeField] protected float maxHealth;
        [SerializeField] protected float mana;
        [SerializeField] protected float maxMana;

        [Header("Equipment Stats")]
        [SerializeField] protected float damage;
        [SerializeField] protected float armor;
        [SerializeField] protected float magicalDamage;
    }
}
