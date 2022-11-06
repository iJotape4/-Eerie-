using UnityEngine;
using UnityEngine.Events;

namespace GameEvents
{
    [CreateAssetMenu(fileName = "Interactable Events", menuName = "ScriptableObjects/Events/Interactable Events", order = 1)]
    public class InteractableEventsScriptableObject : ScriptableObject
    {
        #region PickableItemsEvents
        [System.NonSerialized] public UnityAction<float[]> biblePickedEvent;
        [System.NonSerialized] public UnityAction<float[]>  leftBible;

        [System.NonSerialized] public UnityAction<float[]> holyWaterPickedEvent;
        [System.NonSerialized] public UnityAction<float[]>  leftHolyWater;

        [System.NonSerialized] public UnityAction<float[]> boomerangPickedEvent;
        [System.NonSerialized] public UnityAction<float[]>  leftBoomerang;

        [System.NonSerialized] public UnityAction<float[]> bootsPickedEvent;
        [System.NonSerialized] public UnityAction<float[]>  leftBoots;

        [System.NonSerialized] public UnityAction yellowCardPickedEvent;
        [System.NonSerialized] public UnityAction pinkCardPickedEvent;

        #endregion

        public void PickBible(float[] stats)=> biblePickedEvent?.Invoke(stats);      
        public void LeftBible(float[] stats)=> leftBible?.Invoke(stats);
        
        public void PickHolyWater(float[] stats)=> holyWaterPickedEvent?.Invoke(stats);      
        public void LeftHolyWater(float[] stats)=> leftHolyWater?.Invoke(stats);

        public void PickBoomerang(float[] stats)=> boomerangPickedEvent?.Invoke(stats);      
        public void LeftBoomerang(float[] stats)=> leftBoomerang?.Invoke(stats);

        public void PickBoots(float[] stats)=> bootsPickedEvent?.Invoke(stats);      
        public void LeftBoots(float[] stats)=> leftBoots?.Invoke(stats);      

        public void PickYellowCard()=> yellowCardPickedEvent?.Invoke(); 
        public void PickPinkCard()=> pinkCardPickedEvent?.Invoke(); 

    }
}
