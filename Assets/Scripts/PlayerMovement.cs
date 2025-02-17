using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement Settings")]
    [SerializeField] private float moveSpeed = 7f;

    [Header("Jump Settings")]
    [SerializeField] private float jumpForce = 5f;
    [SerializeField] private int maxJumpCount = 2;

    [Header("Dash Settings")]
    [SerializeField] private float dashSpeed = 35f;
    [SerializeField] private float dashDuration = 0.4f;

    private Rigidbody rb;
    private Transform cameraTransform;

    private int currentJumpCount = 0;
    private bool isDashing = false;
    private float dashTimer = 0f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        cameraTransform = Camera.main.transform;

        // Ensure in the Inspector > Rigidbody > Constraints:
        //    - Freeze Rotation X and Z (checked)
        //    - Freeze Rotation Y (unchecked)
    }

    void Update()
    {
        // 1. Movement Input (WASD)
        Vector2 input = InputManager.Instance.MovementInput;

        // Camera-relative directions (flatten out Y to avoid tilting)
        Vector3 cameraForward = cameraTransform.forward;
        Vector3 cameraRight = cameraTransform.right;
        cameraForward.y = 0f;
        cameraRight.y = 0f;
        cameraForward.Normalize();
        cameraRight.Normalize();

        // Movement direction relative to the camera
        Vector3 moveDirection = (cameraForward * input.y + cameraRight * input.x).normalized;

        // 2. Jump
        if (InputManager.Instance.JumpPressed && currentJumpCount < maxJumpCount)
        {
            Jump();
        }

        // 3. Dash (Q key)
        if (Input.GetKeyDown(KeyCode.Q) && !isDashing)
        {
            StartDash();
        }

        // If we are dashing, count down dash timer
        if (isDashing)
        {
            dashTimer -= Time.deltaTime;
            if (dashTimer <= 0f)
            {
                EndDash();
            }
        }

        // 4. Regular Movement & Rotation if not dashing
        if (!isDashing)
        {
            // Keep current Y velocity so jumping doesn't get overwritten
            float currentVelY = rb.linearVelocity.y;

            if (moveDirection != Vector3.zero)
            {
                // (a) Rotate to face movement direction
                // Instant:
                transform.forward = moveDirection;

                // Optional: Smooth rotation approach
                /*
                float rotationSpeed = 10f;
                Quaternion targetRot = Quaternion.LookRotation(moveDirection);
                transform.rotation = Quaternion.Slerp(transform.rotation, targetRot, rotationSpeed * Time.deltaTime);
                */

                // (b) Move
                rb.linearVelocity = new Vector3(moveDirection.x * moveSpeed, currentVelY, moveDirection.z * moveSpeed);
            }
            else
            {
                // No horizontal input
                rb.linearVelocity = new Vector3(0f, currentVelY, 0f);
            }
        }
    }

    private void Jump()
    {
        // Optionally zero out vertical velocity for consistent jumps
        Vector3 vel = rb.linearVelocity;
        vel.y = 0f;
        rb.linearVelocity = vel;

        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        currentJumpCount++;
    }

    private void StartDash()
    {
        isDashing = true;
        dashTimer = dashDuration;

        // Since we're rotating the player above, transform.forward is correct
        Vector3 dashDirection = transform.forward;
        dashDirection.y = 0f;  // Ensure no upward dash
        dashDirection.Normalize();

        rb.linearVelocity = dashDirection * dashSpeed;
    }

    private void EndDash()
    {
        isDashing = false;
        // You could optionally reset or preserve velocity here
        // e.g. rb.velocity = Vector3.zero;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            currentJumpCount = 0;
        }
    }
}

