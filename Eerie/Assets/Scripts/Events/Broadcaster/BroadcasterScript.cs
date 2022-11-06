using UnityEngine;

namespace GameEvents
{
    public class BroadcasterScript : MonoBehaviour
    {
        public PlayerStatsScriptableObject playerEvents;
        public GameManagerScriptableObject gameStateEvents;
        public UIManagerScriptableObject uiEvents;
        public InteractableEventsScriptableObject interactionsEvents;

        private void Start() 
        {
            playerEvents.deathEvent += CallGameOver;
            playerEvents.interactableFoundEvent += ActivatePressEIcon;

            interactionsEvents.biblePickedEvent += WeaponPicked;
            interactionsEvents.holyWaterPickedEvent += WeaponPicked;
            interactionsEvents.bootsPickedEvent += WeaponPicked;
            interactionsEvents.boomerangPickedEvent += WeaponPicked;
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

        void WeaponPicked(float[] stats)
        {
            playerEvents.WeaponPicked(stats);
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
