using UnityEngine;
using UnityEngine.Events;
using PlayerScripts;

namespace GameEvents
{
    [CreateAssetMenu(fileName = "Player Events", menuName = "ScriptableObjects/Events/Player Events", order = 1)]
    public class PlayerEvents : ScriptableObject
    {
    public PlayerStatsScriptableObject playerStats;

        [HideInInspector] public UnityAction<float> healthChangeEvent;
        [HideInInspector] public UnityAction<float> damageChangeEvent;
        [HideInInspector] public UnityAction<float> armorChangeEvent;

        public void RaisedHealthChangeEvent(float health) =>
            healthChangeEvent?.Invoke(health);
        
        public void RaisedDamageChangeEvent(float damage) =>
            damageChangeEvent?.Invoke(damage);

        public void RaisedArmorChangeEvent(float armor) =>
            armorChangeEvent?.Invoke(armor);
    }
}
