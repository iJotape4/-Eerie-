using UnityEngine;

namespace GameEvents
{
    public class BroadcasterScript : MonoBehaviour
    {
        public PlayerStatsScriptableObject playerEvents;
        public GameManagerScriptableObject gameStateEvents;

        private void Start() 
        {
            playerEvents.deathEvent += CallGameOver;
        }

        void CallGameOver()
        {
            gameStateEvents.Lose();
        }


        #region playerEvents
        /*public void ChangePlayerHealth(float health) 
        {
            if(playerEvents == null)
                return;
            playerEvents.healthChangeEvent(health);
        }

        public void ChangePlayerArmor(float armor) 
        {
            if(playerEvents == null)
                return;
            playerEvents.armorChangeEvent(armor);
        }

        public void ChangePlayerDamage(float damage) 
        {
            if(playerEvents == null)
                return;
            playerEvents.damageChangeEvent(damage);
        }*/
        #endregion
    }
}
