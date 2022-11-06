using UnityEngine;

namespace GameEvents
{
    public class BroadcasterScript : MonoBehaviour
    {
        public PlayerStatsScriptableObject playerEvents;
        public GameManagerScriptableObject gameStateEvents;
        public UIManagerScriptableObject uiEvents;

        private void Start() 
        {
            playerEvents.deathEvent += CallGameOver;
            playerEvents.interactableFoundEvent += ActivatePressEIcon;
        }

        void CallGameOver()
        {
            gameStateEvents.Lose();
        }
        
        void ActivatePressEIcon(bool value)
        {
            if(value)
            {
                uiEvents.ActivatePressEIcon();
            }
            else
            {
                uiEvents.DeactivatePressEIcon();
            }
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
