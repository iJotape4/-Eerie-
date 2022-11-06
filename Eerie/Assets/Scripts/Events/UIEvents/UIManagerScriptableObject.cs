using UnityEngine;
using UnityEngine.Events;

namespace GameEvents
{
    [CreateAssetMenu(fileName = "UiManagerScriptableObject", menuName = "ScriptableObjects/Events/UiManagerScriptableObject", order = 0)]
    public class UIManagerScriptableObject : ScriptableObject 
    {
        public UnityAction<bool> togglePressEIconEvent;       

        public void ActivatePressEIcon()=>
        togglePressEIconEvent?.Invoke(true);

        public void DeactivatePressEIcon()=>
        togglePressEIconEvent?.Invoke(false);
    }
}


