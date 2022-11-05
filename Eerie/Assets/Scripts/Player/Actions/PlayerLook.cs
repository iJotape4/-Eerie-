using UnityEngine;

namespace PlayerScripts
{
    public class PlayerLook : MonoBehaviour
    {
        [SerializeField, Range(0.1f, 50f)] float sensivityX =8f;
        [SerializeField, Range(0.1f, 50f)] float sensivityY =0.1f;
        float mouseX, mouseY;

        [SerializeField] Transform playerCamera;
        [SerializeField] float xClamp = 85f;    
        float xRotation =0f;
        
        void Start()
        {
            playerCamera = GetComponentInChildren<Camera>().transform;
            Cursor.lockState = CursorLockMode.Locked;
        }

        // Update is called once per frame
        void Update()
        {
            transform.Rotate(Vector3.up , mouseX*Time.deltaTime);

            xRotation -= mouseY;
            xRotation = Mathf.Clamp(xRotation, -xClamp, xClamp);
            Vector3 targetRotation = transform.eulerAngles;
            targetRotation.x = xRotation;
            playerCamera.eulerAngles = targetRotation;
        }

        public void ReceiveInput(Vector2 mouseInput)
        {
            mouseX = mouseInput.x *sensivityX;
            mouseY = mouseInput.y *sensivityY;
        }
    }     
}
