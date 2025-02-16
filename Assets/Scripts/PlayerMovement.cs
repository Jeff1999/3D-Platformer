using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 7f;
    private Rigidbody rb;
    private Transform cameraTransform;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        // Get the main camera's transform
        cameraTransform = Camera.main.transform;
    }

    void Update()
    {
        Vector2 input = InputManager.Instance.MovementInput;

        // Get camera's forward and right vectors but ignore Y component
        Vector3 cameraForward = cameraTransform.forward;
        Vector3 cameraRight = cameraTransform.right;

        cameraForward.y = 0;
        cameraRight.y = 0;
        cameraForward.Normalize();
        cameraRight.Normalize();

        // Calculate movement direction relative to camera
        Vector3 moveDirection = (cameraForward * input.y + cameraRight * input.x).normalized;

        if (moveDirection != Vector3.zero)
        {
            rb.linearVelocity = new Vector3(moveDirection.x * moveSpeed, rb.linearVelocity.y, moveDirection.z * moveSpeed);
        }
        else
        {
            rb.linearVelocity = new Vector3(0, rb.linearVelocity.y, 0);
        }
    }
}



