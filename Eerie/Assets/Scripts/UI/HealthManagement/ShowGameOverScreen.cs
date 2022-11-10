using UnityEngine;
using UnityEngine.UI;
using System.Collections;

namespace UIManager
{
    public class ShowGameOverScreen : MonoBehaviour
    {
        [SerializeField] private Image gameOverImage;
        [HideInInspector] private UIManagerListener uIManager;
            
            private void Start() 
            {
                uIManager = GetComponent<UIManagerListener>();
                uIManager.uiManagerScriptableObject.displayGameOverEvent += ShowGameOverPanel;
                gameOverImage.enabled=false;
            }
            

            public void ShowGameOverPanel()=>
                gameOverImage.enabled=true;
            
    }
}