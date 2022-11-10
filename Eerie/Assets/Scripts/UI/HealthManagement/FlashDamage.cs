using UnityEngine;
using UnityEngine.UI;
using System.Collections;

namespace UIManager
{
    public class FlashDamage : MonoBehaviour
    {
        [SerializeField] private Image DamageImage;
        [HideInInspector] private UIManagerListener uIManager;
            
            private void Start() 
            {
                uIManager = GetComponent<UIManagerListener>();
                uIManager.uiManagerScriptableObject.displayDamageFlashEvent += FlashRedPanel;
                DamageImage.enabled=false;
            }
            

            public void FlashRedPanel()
            {
                StartCoroutine(FashRedPanel());
            }

            public IEnumerator FashRedPanel()
            {
                DamageImage.enabled = true;  
                yield return new WaitForEndOfFrame();
                DamageImage.enabled =false;       
            }
    }
}
