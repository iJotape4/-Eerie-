using UnityEngine;

namespace GameEvents
{
    public class BroadcasterScript : MonoBehaviour
    {
        public PlayerEvents playerEvents;

        #region playerEvents
        public void ChangePlayerHealth(float health) 
        {
            if(playerEvents == null)
                return;
            playerEvents.RaisedHealthChangeEvent(health);
        }

        public void ChangePlayerArmor(float armor) 
        {
            if(playerEvents == null)
                return;
            playerEvents.RaisedArmorChangeEvent(armor);
        }

        public void ChangePlayerDamage(float damage) 
        {
            if(playerEvents == null)
                return;
            playerEvents.RaisedDamageChangeEvent(damage);
        }
        #endregion
    }
}
