using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace UIManager
{
    public class PressEIcon : MonoBehaviour
    {
        [SerializeField] private Image pressEIcon;
        [HideInInspector] private UIManagerListener uIManager;
        
        private void Start() 
        {
            uIManager = GetComponent<UIManagerListener>();
           uIManager.uiManagerScriptableObject.togglePressEIconEvent += TogglePressEIcon;
           uIManager.uiManagerScriptableObject.DeactivatePressEIcon();
        }
        

        public void TogglePressEIcon(bool value)
        {
            pressEIcon.enabled = value;        
        }
    }
}
