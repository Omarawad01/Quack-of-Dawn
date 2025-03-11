using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    [Header("Movement Settings")]
    public float moveSpeed = 5f;            // Movement speed for the character
    public float jumpForce = 5f;            // Force applied when jumping
    public float gravity = -9.81f;          // Gravity force (should be negative)

    [Header("Mouse Look Settings")]
    public float mouseSensitivity = 100f;   // Mouse sensitivity for looking around
    public float verticalRotationLimit = 80f; // Maximum up/down angle in degrees

    [Header("Camera")]
    public Camera playerCamera;             // Reference to the Camera for vertical rotation

    // Internal variables for mouse look and movement
    private float xRotation = 0f;
    private CharacterController characterController;
    private Vector3 velocity;               // Current velocity (used for gravity and jump)
    private bool isGrounded;

    void Start()
    {
        // Get the CharacterController component attached to this GameObject
        characterController = GetComponent<CharacterController>();
        if (characterController == null)
        {
            Debug.LogError("CharacterMovement requires a CharacterController component.");
        }

        // If no camera is assigned, try to find the main camera
        if (playerCamera == null)
        {
            playerCamera = Camera.main;
        }

        // Lock the cursor for a more immersive experience
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        HandleMouseLook();
        HandleMovement();
    }

    // Handles mouse look for horizontal rotation (character) and vertical rotation (camera)
    void HandleMouseLook()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        // Rotate the character horizontally
        transform.Rotate(Vector3.up * mouseX);

        // Adjust vertical rotation and clamp it to the set limits
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -verticalRotationLimit, verticalRotationLimit);

        // Apply vertical rotation to the camera
        if (playerCamera != null)
        {
            playerCamera.transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        }
    }

    // Handles movement including walking, jumping, and applying gravity
    void HandleMovement()
    {
        // Check if the character is grounded
        isGrounded = characterController.isGrounded;
        if (isGrounded && velocity.y < 0)
        {
            // Small downward force to keep the character grounded
            velocity.y = -2f;
        }

        // Get keyboard input for horizontal and vertical movement (WASD/Arrow keys)
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        // Calculate the movement direction relative to the character's orientation
        Vector3 move = transform.right * moveHorizontal + transform.forward * moveVertical;
        characterController.Move(move * moveSpeed * Time.deltaTime);

        // Handle jumping: if Jump button (default is space) is pressed and character is grounded
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            // Using the formula: velocity = sqrt(jumpForce * -2 * gravity)
            velocity.y = Mathf.Sqrt(jumpForce * -2f * gravity);
        }

        // Apply gravity over time
        velocity.y += gravity * Time.deltaTime;
        characterController.Move(velocity * Time.deltaTime);
    }
}
