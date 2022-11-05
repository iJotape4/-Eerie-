using UnityEngine;
namespace PlayerScripts
{
    public class PlayerMovement : MonoBehaviour
    {
        [Range(0.1f, 50f)] public float playerSpeed = 10f;
        [Range(0.1f, 50f)] public float jumpForce=10f;
        Vector2 _horizontalInput;
        bool _jump;
            //[HideInInspector] Vector3 mass;
            [SerializeField] Transform groundCheck;
            [SerializeField, Range(0.1f, 1f)] float groundCheckArea =0.3f;
            [SerializeField] private LayerMask groundMask;
            [SerializeField] private bool isGrounded;

            [SerializeField] public Rigidbody rb;
            [SerializeField] public float speedMultiplier=10f;
            [SerializeField] public float rbDrag =8f;

            public void ReceiveInput(Vector2 moveInput, bool jump)
            {
                _horizontalInput = moveInput;
                _jump = jump;
            }
            // Start is called before the first frame update
            public void Start()
            {
                rb = GetComponent<Rigidbody>();
                rb.freezeRotation = true;             
            }

            void Update()=>
                ControlDrag();           

            private void FixedUpdate()=>
                manageMovement();              

            void ControlDrag()=>
                rb.drag = rbDrag;

            void manageMovement()
            {
                isGrounded = Physics.CheckSphere(groundCheck.position, groundCheckArea, groundMask);

               float x = _horizontalInput.x;
                float y = _horizontalInput.y;

                Vector3 movement = transform.right * x + transform.forward * y;
                rb.AddForce(movement *playerSpeed *speedMultiplier , ForceMode.Acceleration);
                if (_jump  && isGrounded)
                    {
                        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
                    }       
            }
    }
}

